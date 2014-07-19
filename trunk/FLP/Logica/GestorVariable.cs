using AccesoDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class GestorVariable
    {
        public void registrarVariable(string nombre, string abreviacion, string color, decimal a, decimal b, decimal c)
        {
            try
            {
                if (b < a)
                    throw new Exception("el valor de <strong>b</strong> debe ser mayor o igual al de <strong>a</strong>");
                if (c < b)
                    throw new Exception("el valor de <strong>c</strong> debe ser mayor o igual al de <strong>b</strong>");
                Variable variable = new Variable() { nombre = nombre, abreviacion = abreviacion, color = color, a=a, b=b, c=c };
                Proyecto proyecto = (Proyecto)System.Web.HttpContext.Current.Session["proyecto"];
                DAOVariable daoVariable = new DAOVariable();
                variable.idVariable = daoVariable.registrarVariable(variable, proyecto);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Variable> obtenerVariablesPorProyecto()
        {
            Proyecto proyecto = (Proyecto)System.Web.HttpContext.Current.Session["proyecto"];
            if (proyecto == null)
                throw new Exception("No hay un proyecto seleccionado");
            DAOVariable daoVariable = new DAOVariable();
            return daoVariable.obtenerVariablesPorProyecto(proyecto.idProyecto);
        }

        public Variable obtenerVariablePorId(int IdVariable)
        {
            DAOVariable daoVariable = new DAOVariable();
            Variable variable = daoVariable.obtenerVariablePorId(IdVariable);
            if (variable == null)
                throw new Exception("No existe ningun criterio con ese id");
            return variable;
        }

        public void modificarVariable(string nombre, string abreviacion, string color, decimal a, decimal b, decimal c)
        {
            try
            {
                Variable variableVieja = (Variable)System.Web.HttpContext.Current.Session["variable"];
                Variable variableNueva = new Variable() { idVariable = variableVieja.idVariable, idProyecto = variableVieja.idProyecto, nombre = nombre, abreviacion = abreviacion, color = color, a=a, b=b, c=c };
                DAOVariable daoVariable = new DAOVariable();
                daoVariable.modificarVariable(variableNueva);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void eliminarVariablePorId()
        {
            DAOVariable daoVariable = new DAOVariable();
            Variable variable = (Variable)System.Web.HttpContext.Current.Session["variable"];
            if (variable == null)
                throw new Exception("No existe ninguna Variable con ese id");
            daoVariable.eliminarVariablePorId(variable.idVariable);
        }

        public string obtenerGraficoVariables()
        {
            DAOVariable daoVariable = new DAOVariable();
            Proyecto proyecto = (Proyecto)System.Web.HttpContext.Current.Session["proyecto"];
            List<Variable> variables = daoVariable.obtenerVariablesPorProyecto(proyecto.idProyecto);
            if (variables == null)
                throw new Exception("No existen variables para el proyecto");


            //[['x', 'MB', 'B', 'MEB', 'ME', 'MEA', 'A', 'MA',], 
            string resultado = "[['x', ";
            foreach (Variable variable in variables)
            {
                resultado += "'" + variable.abreviacion + "', ";
            }
            resultado += "],";
            List<decimal> listaX = obtenerValoresEjeX(variables);
            listaX.Sort();
            foreach (decimal valorX in listaX)
            {
                resultado += "[" + valorX.ToString(System.Globalization.CultureInfo.InvariantCulture) + ",";
                foreach (Variable variable in variables)
                {
                    decimal valorY = obtenerValorYparaX(valorX, variable);
                    string stringY;
                    if (valorY == -9909)
                        stringY = "null";
                    else
                        stringY = valorY.ToString(System.Globalization.CultureInfo.InvariantCulture);
                    resultado +=  stringY + ", ";
                }
                resultado += "],";
            }
            resultado += "],[";
            foreach (Variable variable in variables)
            {
                resultado += "'" + variable.color + "', ";
            }
            resultado += "]";
            return resultado;
        }

        public List<decimal> obtenerValoresEjeX(List<Variable> variables)
        {
            if (variables == null)
                throw new Exception("Error al obtener valores eje x. La lista de variables es nula");
            List<decimal> valoresX= new List<decimal>();
            foreach (Variable variable in variables)
	        {
                if(!existeEnLista(variable.a, valoresX))
                    valoresX.Add(variable.a);
                if(!existeEnLista(variable.b, valoresX))
                    valoresX.Add(variable.b);
                if(!existeEnLista(variable.c, valoresX))
                    valoresX.Add(variable.c);
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

        public decimal obtenerValorYparaX(decimal x, Variable variable)
        {
            decimal a = variable.a;
            decimal b = variable.b;
            decimal c = variable.c;
            if (x < a)
                return -9909;
            if(x <= a && x < b)
                return 0;
            else if(x == a && x == b)
                return 1;
            else if(x > a && x <= b)
                return ((x-a)/(b-a));
            else if(x > b && x < c)
                return ((c-x)/(c-b));
            else if(x == b && x == c)
                return 1;
            else if(x == c)
                return 0;
            else if (x > c)
                return -9909;
            return -99010;
        }

        public int obtenerCantVariablesPorProyecto()
        {
            DAOVariable daoVariable = new DAOVariable();
            Proyecto proyecto = (Proyecto)System.Web.HttpContext.Current.Session["proyecto"];
            return daoVariable.obtenerCantVariablesPorProyecto(proyecto.idProyecto);
        }
    }
}
