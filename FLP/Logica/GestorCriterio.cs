using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using AccesoDatos;

namespace Logica
{
    public class GestorCriterio
    {
        public void registrarCriterio(string nombre, string abreviacion, int peso, string color)
        {
            try
            {
                Criterio criterio = new Criterio() { nombre = nombre, abreviacion = abreviacion, peso = peso, color = color };
                Proyecto proyecto = (Proyecto)System.Web.HttpContext.Current.Session["proyecto"];
                DAOCriterio daoCriterio = new DAOCriterio();
                criterio.idCriterio = daoCriterio.registrarCriterio(criterio, proyecto);
                if (proyecto.listaCriterios == null)
                    proyecto.listaCriterios = new List<Criterio>();
                proyecto.listaCriterios.Add(criterio);
                System.Web.HttpContext.Current.Session["proyecto"] = proyecto;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
