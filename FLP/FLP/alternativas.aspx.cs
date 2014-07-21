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
    public partial class alternativas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    cargarRepeatersCriterios();
                    cargarRepeaterAlternativas();
                }
                catch (Exception ex)
                {
                    mostrarError();
                    litError.Text = ex.Message;
                }
            }
        }

        protected void rptValoracionesCriterios_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                GestorVariable gestor = new GestorVariable();
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    DropDownList ddlVariables = (DropDownList)e.Item.FindControl("ddlVariables");
                    Criterio criterio = ((Criterio)e.Item.DataItem);
                    HiddenField txtIdCriterio = (HiddenField)e.Item.FindControl("txtIdCriterio");
                    txtIdCriterio.Value = criterio.idCriterio.ToString();
                    ddlVariables.DataSource = gestor.obtenerVariablesPorProyecto();
                    ddlVariables.DataTextField = "abreviacion";
                    ddlVariables.DataValueField = "idVariable";
                    ddlVariables.DataBind();
                    ListItem tituloCriterio = new ListItem(criterio.nombre, "", true);
                    tituloCriterio.Selected = true;
                    tituloCriterio.Attributes.Add("disabled", "disabled");
                    ddlVariables.Items.Insert(0, tituloCriterio);
                }
            }
            catch (Exception ex)
            {
                Label lblMensajeEdiciones = (Label)e.Item.FindControl("lblMensajeEdiciones");
                lblMensajeEdiciones.Text = ex.Message;
            }
        }

        protected void rptAlternativas_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            try
            {
                reestablecerPantalla();
                GestorAlternativa gestor = new GestorAlternativa();
                if (e.CommandName == "editar")
                {
                    int idAlternativa = int.Parse(e.CommandArgument.ToString());
                    Alternativa alternativa = gestor.obtenerAlternativaPorId(idAlternativa);
                    Session["alternativa"] = alternativa;
                    txtNombre.Value = alternativa.nombre;
                    txtAbreviacion.Value = alternativa.abreviacion;
                    txtColor.Value = alternativa.color;
                    int i = 0;
                    foreach (RepeaterItem item in rptValoracionesCriterios.Items)
                    {
                        DropDownList ddlVariables = (DropDownList)item.FindControl("ddlVariables");
                        HiddenField txtIdCriterio = (HiddenField)item.FindControl("txtIdCriterio");
                        if (i < alternativa.listaDetallesAlternativa.Count)
                        {
                            ddlVariables.SelectedValue = alternativa.listaDetallesAlternativa.ElementAt(i).variable.idVariable.ToString();
                            txtIdCriterio.Value = alternativa.listaDetallesAlternativa.ElementAt(i).criterio.idCriterio.ToString();
                        }
                        i++;
                    }
                    btnAgregar.Visible = false;
                    btnModificar.Visible = true;
                    btnCancelar.Visible = true;
                }
                if (e.CommandName == "eliminar")
                {
                    Alternativa alternativa = gestor.obtenerAlternativaPorId(int.Parse(e.CommandArgument.ToString()));
                    Session["alternativa"] = alternativa;
                    litNombreAlternativa.Text = alternativa.nombre;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalEliminar();", true);
                }
                cargarGrafico();
            }
            catch (Exception ex)
            {
                mostrarError();
                litError.Text = ex.Message;
            }
        }

        protected void rptAlternativas_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                GestorAlternativa gestor = new GestorAlternativa();
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    Repeater rptValoracionAlternativa = (Repeater)e.Item.FindControl("rptValoracionAlternativa");
                    rptValoracionAlternativa.DataSource = ((Alternativa)e.Item.DataItem).listaDetallesAlternativa;
                    rptValoracionAlternativa.DataBind();
                }
            }
            catch (Exception ex)
            {
                mostrarError();
                litError.Text = ex.Message;
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                litError.Visible = false;
                List<DetalleAlternativa> listaValoraciones = new List<DetalleAlternativa>();
                foreach (RepeaterItem itemCriterio in rptValoracionesCriterios.Items)
                {
                    DropDownList ddlVariables = (DropDownList)itemCriterio.FindControl("ddlVariables");
                    HiddenField txtIdCriterio = (HiddenField)itemCriterio.FindControl("txtIdCriterio");
                    DetalleAlternativa valoracion = new DetalleAlternativa();
                    valoracion.criterio.idCriterio = int.Parse(txtIdCriterio.Value);
                    valoracion.variable.idVariable = int.Parse(ddlVariables.SelectedValue);
                    listaValoraciones.Add(valoracion);
                }
                GestorAlternativa gestor = new GestorAlternativa();
                gestor.registrarAlternativa(txtNombre.Value, txtAbreviacion.Value, txtColor.Value, listaValoraciones);
                reestablecerPantalla();
                cargarRepeaterAlternativas();
            }
            catch (Exception ex)
            {
                mostrarError();
                litError.Text = ex.Message;
            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                List<DetalleAlternativa> listaValoraciones = new List<DetalleAlternativa>();
                foreach (RepeaterItem itemCriterio in rptValoracionesCriterios.Items)
                {
                    DropDownList ddlVariables = (DropDownList)itemCriterio.FindControl("ddlVariables");
                    HiddenField txtIdCriterio = (HiddenField)itemCriterio.FindControl("txtIdCriterio");
                    DetalleAlternativa valoracion = new DetalleAlternativa();
                    valoracion.criterio.idCriterio = int.Parse(txtIdCriterio.Value);
                    valoracion.variable.idVariable = int.Parse(ddlVariables.SelectedValue);
                    listaValoraciones.Add(valoracion);
                }
                GestorAlternativa gestor = new GestorAlternativa();
                gestor.modificarAlternativa(txtNombre.Value, txtAbreviacion.Value, txtColor.Value, listaValoraciones);
                reestablecerPantalla();
                cargarRepeaterAlternativas();
            }
            catch (Exception ex)
            {
                mostrarError();
                litError.Text = ex.Message;
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            reestablecerPantalla();
            cargarGrafico();
        }

        protected void btnCancelarEliminacion_Click(object sender, EventArgs e)
        {
            reestablecerPantalla();
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "closeModalEliminar();", true);
                GestorAlternativa gestor = new GestorAlternativa();
                gestor.eliminarAlternativaPorId();
                cargarRepeaterAlternativas();
                reestablecerPantalla();
            }
            catch (Exception ex)
            {
                mostrarError();
                litError.Text = ex.Message;
            }
        }

        protected void btnSiguiente_Click(object sender, EventArgs e)
        {
            GestorAlternativa gestor = new GestorAlternativa();
            if (gestor.obtenerCantAlternativasPorProyecto() > 0)
                Response.Redirect("generar-informe.aspx");
            else
            {
                mostrarError();
                litError.Text = "Debe cargar al menos una alternativa!";
            }
        }

        //-------------------------------------------------
        //----------Metodos Auxiliares---------------------
        //-------------------------------------------------
        private void cargarRepeatersCriterios()
        {
            GestorCriterio gestor = new GestorCriterio();
            List<Criterio> listaCriterios = gestor.obtenerCriteriosPorProyecto();
            rptValoracionesCriterios.DataSource = listaCriterios;
            rptValoracionesCriterios.DataBind();
            rptCriteriosTabla.DataSource = listaCriterios;
            rptCriteriosTabla.DataBind();
        }
        private void cargarRepeaterAlternativas()
        {
            GestorAlternativa gestor = new GestorAlternativa();
            rptAlternativas.DataSource = gestor.obtenerAlternativasPorProyecto();
            rptAlternativas.DataBind();
            cargarGrafico();
        }
        private void mostrarError()
        {
            panFracaso.Visible = true;
            litError.Visible = true;
        }
        protected void reestablecerPantalla()
        {
            panFracaso.Visible = false;
            Session["alternativa"] = null;
            txtNombre.Value = "";
            txtAbreviacion.Value = "";
            txtColor.Value = "#E1E1E1";
            foreach (RepeaterItem itemCriterio in rptValoracionesCriterios.Items)
            {
                DropDownList ddlVariables = (DropDownList)itemCriterio.FindControl("ddlVariables");
                ddlVariables.SelectedValue="";
                ddlVariables.SelectedItem.Attributes.Add("disabled", "disabled");
            }
            btnAgregar.Visible = true;
            btnModificar.Visible = false;
            btnCancelar.Visible = false;
        }
        private void cargarGrafico()
        {
            GestorAlternativa gestor = new GestorAlternativa();
            if(gestor.obtenerCantAlternativasPorProyecto() > 0)
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alternativas", "drawAlternativas(" + gestor.obtenerGraficoAlternativas() + ");", true);
        }
        protected decimal obtenerCentrodeGravedad(Resultado resultado)
        {
            return resultado.obtenerCentroGravedad();
        }
        protected string obtenerTipoCriterio(Object esTipoMax)
        {
            if ((bool)esTipoMax)
                return "glyphicon glyphicon-arrow-up";
            return "glyphicon glyphicon-arrow-down";
        }
    }
}