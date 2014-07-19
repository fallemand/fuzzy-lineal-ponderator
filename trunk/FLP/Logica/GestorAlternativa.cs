using AccesoDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class GestorAlternativa
    {
        public void registrarAlternativa(string nombre, string abreviacion, string color, List<DetalleAlternativa> listaValoraciones)
        {
            try
            {
                if (listaValoraciones.Count==0)
                    throw new Exception("No ha asignado criterios a esta alternativa");
                Proyecto proyecto = (Proyecto)System.Web.HttpContext.Current.Session["proyecto"];
                Alternativa alternativa = new Alternativa() { idProyecto = proyecto.idProyecto, nombre = nombre, abreviacion = abreviacion, color = color, listaDetallesAlternativa = listaValoraciones };
                DAOAlternativa daoAlternativa = new DAOAlternativa();
                daoAlternativa.registrarAlternativa(alternativa);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Alternativa> obtenerAlternativasPorProyecto()
        {
            Proyecto proyecto = (Proyecto)System.Web.HttpContext.Current.Session["proyecto"];
            if (proyecto == null)
                throw new Exception("No hay un proyecto seleccionado");
            DAOAlternativa daoAlternativa = new DAOAlternativa();
            List<Alternativa> alternativas = daoAlternativa.obtenerAlternativasPorProyecto(proyecto.idProyecto);
            GestorCriterio gestorCriterio = new GestorCriterio();
            GestorVariable gestorVariable = new GestorVariable();
            foreach (Alternativa alternativa in alternativas)
            {
                alternativa.listaDetallesAlternativa = daoAlternativa.obtenerDetallesAlternativa(alternativa.idAlternativa);
                foreach (DetalleAlternativa valoracion in alternativa.listaDetallesAlternativa)
                {
                    valoracion.criterio = gestorCriterio.obtenerCriterioPorId(valoracion.criterio.idCriterio);
                    valoracion.variable = gestorVariable.obtenerVariablePorId(valoracion.variable.idVariable);
                }
            }
            return alternativas;
        }

        public Alternativa obtenerAlternativaPorId(int idAlternativa)
        {
            DAOAlternativa daoAlternativa = new DAOAlternativa();
            Alternativa alternativa = daoAlternativa.obtenerAlternativaPorId(idAlternativa);
            GestorCriterio gestorCriterio = new GestorCriterio();
            GestorVariable gestorVariable = new GestorVariable();
            alternativa.listaDetallesAlternativa = daoAlternativa.obtenerDetallesAlternativa(alternativa.idAlternativa);
            foreach (DetalleAlternativa valoracion in alternativa.listaDetallesAlternativa)
            {
                valoracion.criterio = gestorCriterio.obtenerCriterioPorId(valoracion.criterio.idCriterio);
                valoracion.variable = gestorVariable.obtenerVariablePorId(valoracion.variable.idVariable);
            }
            return alternativa;
        }

        public void modificarAlternativa(string nombre, string abreviacion, string color, List<DetalleAlternativa> listaValoraciones)
        {
                if (listaValoraciones.Count == 0)
                    throw new Exception("No ha asignado criterios a esta alternativa");
                Proyecto proyecto = (Proyecto)System.Web.HttpContext.Current.Session["proyecto"];
                Alternativa alternativaVieja = (Alternativa)System.Web.HttpContext.Current.Session["alternativa"];
                Alternativa alternativaNueva = new Alternativa() { idProyecto = proyecto.idProyecto, nombre = nombre, abreviacion = abreviacion, color = color, listaDetallesAlternativa = listaValoraciones };
                DAOAlternativa daoAlternativa = new DAOAlternativa();
                daoAlternativa.modificarAlternativa(alternativaNueva, alternativaVieja.idAlternativa);
        }

        public void eliminarAlternativaPorId()
        {
            DAOAlternativa daoAlternativa = new DAOAlternativa();
            Alternativa alternativa = (Alternativa)System.Web.HttpContext.Current.Session["alternativa"];
            if (alternativa == null)
                throw new Exception("No hay ninguna alternativa seleccionada");
            daoAlternativa.eliminarAlternativaPorId(alternativa.idAlternativa);
        }

        public Resultado generarResultadoAlternativa(Alternativa alternativa)
        {
                decimal a=0;decimal b=0;decimal c=0;
                decimal pesoTotal=0;
                decimal pesoNormalizado = 0;
                foreach (DetalleAlternativa detalle in alternativa.listaDetallesAlternativa)
                    pesoTotal += detalle.criterio.peso;
                foreach (DetalleAlternativa detalle in alternativa.listaDetallesAlternativa)
                {
                    pesoNormalizado = detalle.criterio.peso / pesoTotal;
                    a += pesoNormalizado * detalle.variable.a;
                    b += pesoNormalizado * detalle.variable.b;
                    c += pesoNormalizado * detalle.variable.c;
                }
                Resultado resultado = new Resultado()
                {
                    a = Math.Truncate(1000 * a) / 1000,
                    b = Math.Truncate(1000 * b) / 1000,
                    c = Math.Truncate(1000 * c) / 1000
                };
                return resultado;
        }

        public string obtenerGraficoAlternativas()
        {
            List<Alternativa> listaAlternativas = obtenerAlternativasPorProyecto();
            List<Resultado> listaResultados = new List<Resultado>();
            if (listaAlternativas == null)
                throw new Exception("No existen alternativas para el proyecto");
            string resultado = "[['x', ";
            foreach (Alternativa alternativa in listaAlternativas)
            {
                resultado += "'" + alternativa.abreviacion + "', ";
                listaResultados.Add(generarResultadoAlternativa(alternativa));
            }
            resultado += "],";
            List<decimal> listaX = obtenerValoresEjeX(listaResultados);
            listaX.Sort();
            foreach (decimal valorX in listaX)
            {
                resultado += "['" + valorX + "',";
                foreach (Resultado resultadoAlternativa in listaResultados)
                {
                    decimal valorY = obtenerValorYparaX(valorX, resultadoAlternativa);
                    string stringY;
                    if (valorY == -9909)
                        stringY = "null";
                    else
                        stringY = valorY.ToString(System.Globalization.CultureInfo.InvariantCulture);
                    resultado += stringY + ", ";
                }
                resultado += "],";
            }
            resultado += "],[";
            foreach (Alternativa alternativa in listaAlternativas)
            {
                resultado += "'" + alternativa.color + "', ";
            }
            resultado += "]";
            return resultado;
        }

        public List<decimal> obtenerValoresEjeX(List<Resultado> resultados)
        {
            if (resultados == null)
                throw new Exception("Error al obtener valores eje x. La lista de variables es nula");
            List<decimal> valoresX = new List<decimal>();
            foreach (Resultado resultado in resultados)
            {
                if (!existeEnLista(resultado.a, valoresX))
                    valoresX.Add(resultado.a);
                if (!existeEnLista(resultado.b, valoresX))
                    valoresX.Add(resultado.b);
                if (!existeEnLista(resultado.c, valoresX))
                    valoresX.Add(resultado.c);
            }
            return valoresX;
        }

        public bool existeEnLista(decimal numero, List<decimal> lista)
        {
            foreach (decimal numLista in lista)
            {
                if (numLista == numero)
                    return true;
            }
            return false;
        }

        public decimal obtenerValorYparaX(decimal x, Resultado resultado)
        {
            decimal a = resultado.a;
            decimal b = resultado.b;
            decimal c = resultado.c;
            if (x < a)
                return -9909;
            if (x <= a && x < b)
                return 0;
            else if (x == a && x == b)
                return 1;
            else if (x > a && x <= b)
                return ((x - a) / (b - a));
            else if (x > b && x < c)
                return ((c - x) / (c - b));
            else if (x == b && x == c)
                return 1;
            else if (x == c)
                return 0;
            else if (x > c)
                return -9909;
            return -99010;
        }

        public int obtenerCantAlternativasPorProyecto()
        {
            DAOAlternativa daoAlternativa = new DAOAlternativa();
            Proyecto proyecto = (Proyecto)System.Web.HttpContext.Current.Session["proyecto"];
            return daoAlternativa.obtenerCantAlternativasPorProyecto(proyecto.idProyecto);
        }
    }
}
