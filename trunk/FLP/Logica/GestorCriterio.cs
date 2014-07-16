﻿using System;
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

        public void modificarCriterio(string nombre, string abreviacion, int peso, string color)
        {
            try
            {
                Criterio criterioViejo = (Criterio)System.Web.HttpContext.Current.Session["criterio"];
                Criterio criterioNuevo = new Criterio() { idCriterio = criterioViejo.idCriterio, idProyecto = criterioViejo.idProyecto, nombre = nombre, abreviacion = abreviacion, peso = peso, color = color };
                DAOCriterio daoCriterio = new DAOCriterio();
                daoCriterio.modificarCriterio(criterioNuevo);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable obtenerCriteriosDelProyecto()
        {
            Proyecto proyecto = (Proyecto)System.Web.HttpContext.Current.Session["proyecto"];
            if (proyecto == null)
                throw new Exception("No hay un proyecto seleccionado");
            DAOCriterio daoCriterio = new DAOCriterio();
            return daoCriterio.obtenerCriteriosDelProyecto(proyecto);
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
    }
}