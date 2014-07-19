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
    public class GestorProyecto
    {
        public void registrarProyecto(string nombre)
        {
            try
            {
                Proyecto proyecto = new Proyecto() { nombre = nombre, fecha=DateTime.Now };
                Usuario usuario = (Usuario)System.Web.HttpContext.Current.Session["usuario"];
                DAOProyecto daoProyecto = new DAOProyecto();
                proyecto.idProyecto = daoProyecto.registrarProyecto(proyecto, usuario);
                System.Web.HttpContext.Current.Session["proyecto"] = proyecto;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void modificarProyecto(string nuevoNombre)
        {
            try
            {
                Proyecto proyecto=(Proyecto)System.Web.HttpContext.Current.Session["proyecto"];
                proyecto.nombre = nuevoNombre;
                DAOProyecto daoProyecto = new DAOProyecto();
                daoProyecto.ModificarProyecto(proyecto);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable obtenerTodosDataTable()
        {
            Usuario usuario = (Usuario)System.Web.HttpContext.Current.Session["usuario"];
            DAOProyecto daoProyecto = new DAOProyecto();
            return daoProyecto.obtenerTodosDataTable(usuario);
        }

        public Proyecto obtenerProyectoPorId(int IdProyecto)
        {
            DAOProyecto daoProyecto = new DAOProyecto();
            Proyecto proyecto = daoProyecto.obtenerProyectoPorId(IdProyecto);
            if (proyecto == null)
                throw new Exception("No existe ningun Proyecto con ese id");
            return proyecto;
        }

        public void eliminarProyectoPorId()
        {
            DAOProyecto daoProyecto = new DAOProyecto();
            DAOCriterio daoCriterio = new DAOCriterio();
            Proyecto proyecto = (Proyecto)System.Web.HttpContext.Current.Session["proyecto"];
            if(proyecto==null)
                throw new Exception("No existe ningun Proyecto");
            daoCriterio.eliminarCriterioPorProyecto(proyecto.idProyecto);
            daoProyecto.eliminarProyectoPorId(proyecto.idProyecto);
        }
    }
}
