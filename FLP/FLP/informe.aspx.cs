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
    public partial class informe : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    Proyecto proyecto = (Proyecto)Session["proyecto"];
                    if (proyecto == null)
                        Response.Redirect("mis-proyectos.aspx");
                    Usuario usuario = (Usuario)Session["usuario"];
                    litEmailUsuario.Text = usuario.email;
                    litNombreUsuario.Text = usuario.nombre;
                    litNombreProyecto.Text = proyecto.nombre;
                    cargarRepeaterCriterios();
                    cargarRepeaterVariables();
                    cargarRepeaterAlternativas();
                }
                catch (Exception ex)
                {
                    mostrarError();
                    litError.Text = ex.Message;
                }
            }
        }

        protected void rptAlternativasTd_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                GestorAlternativa gestor = new GestorAlternativa();
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    Repeater rptAlternativaTdValoraciones = (Repeater)e.Item.FindControl("rptAlternativaTdValoraciones");
                    rptAlternativaTdValoraciones.DataSource = ((Alternativa)e.Item.DataItem).listaDetallesAlternativa;
                    rptAlternativaTdValoraciones.DataBind();
                }
                else if (e.Item.ItemType == ListItemType.Header)
                {
                    
                    GestorCriterio gestorCriterio = new GestorCriterio();
                    List<Criterio> listaCriterios = gestorCriterio.obtenerCriteriosPorProyecto();
                    Repeater rptAlternativasTh = (Repeater)e.Item.FindControl("rptAlternativasTh");
                    rptAlternativasTh.DataSource = listaCriterios;
                    rptAlternativasTh.DataBind();
                }
            }
            catch (Exception ex)
            {
                Label lblMensajeEdiciones = (Label)e.Item.FindControl("lblMensajeEdiciones");
                lblMensajeEdiciones.Text = ex.Message;
            }
        }

        protected void cargarRepeaterCriterios()
        {
            GestorCriterio gestor = new GestorCriterio();
            rptCriterios.DataSource = gestor.obtenerCriteriosPorProyectoTable();
            rptCriterios.DataBind();
            cargarGraficoCriterios();
        }

        private void cargarGraficoCriterios()
        {
            GestorCriterio gestor = new GestorCriterio();
            if (gestor.obtenerCantCriteriosPorProyecto() > 0)
                ScriptManager.RegisterStartupScript(this, this.GetType(), "pesosRelativos", "drawPesosRelativos(" + gestor.obtenerGraficoPesosRelativos() + ");", true);
        }

        protected void cargarRepeaterVariables()
        {
            GestorVariable gestor = new GestorVariable();
            rptVariables.DataSource = gestor.obtenerVariablesPorProyecto();
            rptVariables.DataBind();
            cargarGraficoVariables();
        }

        private void cargarGraficoVariables()
        {
            GestorVariable gestor = new GestorVariable();
            if(gestor.obtenerCantVariablesPorProyecto() > 0)
                ScriptManager.RegisterStartupScript(this, this.GetType(), "variables", "drawVariables(" + gestor.obtenerGraficoVariables() + ");", true);
        }

        protected void cargarRepeaterAlternativas()
        {
            GestorAlternativa gestorAlternativa = new GestorAlternativa();
            rptAlternativasTd.DataSource = gestorAlternativa.obtenerAlternativasPorProyecto();
            rptAlternativasTd.DataBind();

            cargarGraficoAlternativas();
        }

        private void cargarGraficoAlternativas()
        {
            GestorAlternativa gestor = new GestorAlternativa();
            if (gestor.obtenerCantAlternativasPorProyecto() > 0)
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alternativas", "drawAlternativas(" + gestor.obtenerGraficoAlternativas() + ");", true);
        }

        private void mostrarError()
        {
            panFracaso.Visible = true;
            litError.Visible = true;
        }

        protected decimal obtenerCentrodeGravedad(Resultado resultado)
        {
            return resultado.obtenerCentroGravedad();
        }

        protected string obtenerTipoCriterio(Object esTipoMax)
        {
            if ((bool)esTipoMax)
                return "Max";
            return "Min";
        }

        protected string obtenerIconCriterio(Object esTipoMax)
        {
            if ((bool)esTipoMax)
                return "glyphicon glyphicon-arrow-up";
            return "glyphicon glyphicon-arrow-down";
        }
    }
}