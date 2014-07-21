using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using AccesoDatos;
using System.Data;

namespace Logica
{
    public class GestorCriterio
    {
        public void registrarCriterio(string nombre, string abreviacion, int peso, string color ) //bool esTipoMax
        {
                Criterio criterio = new Criterio() { nombre = nombre, abreviacion = abreviacion, peso = peso, color = color }; //esTipoMax=esTipoMax
                Proyecto proyecto = (Proyecto)System.Web.HttpContext.Current.Session["proyecto"];
                DAOCriterio daoCriterio = new DAOCriterio();
                criterio.idCriterio = daoCriterio.registrarCriterio(criterio, proyecto);
                if (proyecto.listaCriterios == null)
                    proyecto.listaCriterios = new List<Criterio>();
                proyecto.listaCriterios.Add(criterio);
                System.Web.HttpContext.Current.Session["proyecto"] = proyecto;
        }

        public void modificarCriterio(string nombre, string abreviacion, int peso, string color) //bool esTipoMax
        {
                Criterio criterioViejo = (Criterio)System.Web.HttpContext.Current.Session["criterio"];
                Criterio criterioNuevo = new Criterio() { idCriterio = criterioViejo.idCriterio, idProyecto = criterioViejo.idProyecto, nombre = nombre, abreviacion = abreviacion, peso = peso, color = color }; //esTipoMax=esTipoMax
                DAOCriterio daoCriterio = new DAOCriterio();
                daoCriterio.modificarCriterio(criterioNuevo);
        }

        public DataTable obtenerCriteriosPorProyectoTable()
        {
            Proyecto proyecto = (Proyecto)System.Web.HttpContext.Current.Session["proyecto"];
            if (proyecto == null)
                throw new Exception("No hay un proyecto seleccionado");
            DAOCriterio daoCriterio = new DAOCriterio();
            return daoCriterio.obtenerCriteriosPorProyectoTable(proyecto);
        }

        public List<Criterio> obtenerCriteriosPorProyecto()
        {
            Proyecto proyecto = (Proyecto)System.Web.HttpContext.Current.Session["proyecto"];
            if (proyecto == null)
                throw new Exception("No hay un proyecto seleccionado");
            DAOCriterio daoCriterio = new DAOCriterio();
            return daoCriterio.obtenerCriteriosPorProyectoList(proyecto.idProyecto);
        }

        public Criterio obtenerCriterioPorId(int IdCriterio)
        {
            DAOCriterio daoCriterio = new DAOCriterio();
            Criterio criterio= daoCriterio.obtenerCriterioPorId(IdCriterio);
            if(criterio==null)
                throw new Exception("No existe ningun criterio con ese id");
            return criterio;
        }

        public void eliminarCriterioPorId()
        {
            DAOCriterio daoCriterio = new DAOCriterio();
            Criterio criterio = (Criterio)System.Web.HttpContext.Current.Session["criterio"];
            if (criterio == null)
                throw new Exception("No existe ningun Criterio");
            daoCriterio.eliminarCriterioPorId(criterio.idCriterio);
        }

        public string obtenerGraficoPesosRelativos()
        {
            DAOCriterio daoCriterio = new DAOCriterio();
            Proyecto proyecto = (Proyecto)System.Web.HttpContext.Current.Session["proyecto"];
            List<Criterio> criterios = daoCriterio.obtenerCriteriosPorProyectoList(proyecto.idProyecto);
            if (criterios == null)
                throw new Exception("No existen criterios para el proyecto");
            string resultado = "[";
            foreach (Criterio criterio in criterios)
            {
                resultado += "['" + criterio.nombre + "', " + criterio.peso + "],";
            }
            resultado += "],[";
            foreach (Criterio criterio in criterios)
            {
                resultado += "['" + criterio.color + "',],";
            }
            resultado += "]";
            return resultado;
        }

        public string obtenerGraficoPesos()
        {
            DAOCriterio daoCriterio = new DAOCriterio();
            Proyecto proyecto = (Proyecto)System.Web.HttpContext.Current.Session["proyecto"];
            List<Criterio> criterios = daoCriterio.obtenerCriteriosPorProyectoList(proyecto.idProyecto);
            if (criterios == null)
                throw new Exception("No existen criterios para el proyecto");
            string resultado = "[['Criterio', 'Peso', { role: 'style' }],";
            foreach (Criterio criterio in criterios)
            {
                resultado += "['" + criterio.nombre + "', " + criterio.peso + ", '"+criterio.color+"'],";
            }
            resultado += "]";
            return resultado;
        }

        public int obtenerCantCriteriosPorProyecto()
        {
            DAOCriterio daoCriterio = new DAOCriterio();
            Proyecto proyecto = (Proyecto)System.Web.HttpContext.Current.Session["proyecto"];
            return daoCriterio.obtenerCantCriteriosPorProyecto(proyecto.idProyecto);
        }
    }
}
