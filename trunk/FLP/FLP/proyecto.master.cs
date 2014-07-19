using Entidades;
using Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FLP
{
    public partial class proyecto : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Proyecto proyecto = (Proyecto)Session["proyecto"];
                if (proyecto == null)
                    Response.Redirect("mis-proyectos.aspx");
                litNombreProyecto.Text = proyecto.nombre;
                string thisURL = Request.Url.Segments[Request.Url.Segments.Count()-1];
                switch (thisURL)
                {
                    case "criterios.aspx":
                        barraProgreso.Attributes.Add("style", "width: 25%");
                        litProgreso.Text = "25% Completado";
                        break;
                    case "variables.aspx": 
                        barraProgreso.Attributes.Add("style", "width: 50%");
                        litProgreso.Text = "50% Completado";
                        break;
                    case "alternativas.aspx": 
                        barraProgreso.Attributes.Add("style", "width: 75%");
                        litProgreso.Text = "75% Completado";
                        break;
                    case "generarInforme.aspx": 
                        barraProgreso.Attributes.Add("style", "width: 100%");
                        litProgreso.Text = "100% Completado";
                        break;
                }
                GestorCriterio gestorCritero= new GestorCriterio();
                GestorAlternativa gestorAlternativa = new GestorAlternativa();
                GestorVariable gestorVariables = new GestorVariable();
                int cantVariables= gestorVariables.obtenerCantVariablesPorProyecto();
                int cantAlterntivas= gestorAlternativa.obtenerCantAlternativasPorProyecto();
                int cantCriterios= gestorCritero.obtenerCantCriteriosPorProyecto();
                if (cantCriterios == 0)
                {
                    lbVaribles.Attributes.Add("class", "list-group-item disabled");
                    lbAlterntivas.Attributes.Add("class", "list-group-item disabled");
                    lbGenerarInforme.Attributes.Add("class", "list-group-item disabled");
                }
                else if (cantVariables == 0)
                {
                    lbAlterntivas.Attributes.Add("class", "list-group-item disabled");
                    lbGenerarInforme.Attributes.Add("class", "list-group-item disabled");
                }
                else if(cantAlterntivas==0) {
                    lbGenerarInforme.Attributes.Add("class", "list-group-item disabled");
                }

                litCantCriterios.Text = cantCriterios.ToString();
                litCantAlternativas.Text = cantAlterntivas.ToString();
                litCantVariables.Text = cantVariables.ToString();
            }
        }
    }
}