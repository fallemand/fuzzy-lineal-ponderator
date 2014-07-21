using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using Entidades;

namespace FLP
{
    public partial class criterios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    cargarRepeater();
                }
                catch (Exception ex)
                {
                    mostrarError();
                    litError.Text = ex.Message;
                }
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try 
	        {
                litError.Visible = false;
		        GestorCriterio gestor = new GestorCriterio();
                gestor.registrarCriterio(txtNombre.Value, txtAbreviacion.Value, int.Parse(txtPeso.Value), txtColor.Value); //(int.Parse(ddlTipoCriterio.SelectedValue)!=0)
                reestablecerPantalla();
                cargarRepeater();
	        }
	        catch (Exception ex)
	        {
                mostrarError();
                litError.Text = ex.Message;
	        }
        }

        protected void rptProyectos_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            try
            {
                reestablecerPantalla();
                GestorCriterio gestor = new GestorCriterio();
                if (e.CommandName == "editar")
                {
                    int idCriterio = int.Parse(e.CommandArgument.ToString());
                    Criterio criterio = gestor.obtenerCriterioPorId(idCriterio);
                    Session["criterio"] = criterio;
                    txtNombre.Value = criterio.nombre;
                    txtAbreviacion.Value = criterio.abreviacion;
                    txtPeso.Value = criterio.peso.ToString();
                    txtColor.Value = criterio.color;
                    //ddlTipoCriterio.SelectedValue = Convert.ToInt32(criterio.esTipoMax).ToString();
                    btnAgregar.Visible = false;
                    btnModificar.Visible = true;
                    btnCancelar.Visible = true;
                }
                if (e.CommandName == "eliminar")
                {
                    Criterio criterio = gestor.obtenerCriterioPorId(int.Parse(e.CommandArgument.ToString()));
                    Session["criterio"] = criterio;
                    litNombreCriterio.Text = criterio.nombre;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalEliminar();", true);
                }
                cargarGraficos();
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
                GestorCriterio gestor = new GestorCriterio();
                gestor.modificarCriterio(txtNombre.Value, txtAbreviacion.Value, int.Parse(txtPeso.Value), txtColor.Value); //(int.Parse(ddlTipoCriterio.SelectedValue)!=0)
                reestablecerPantalla();
                cargarRepeater();
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
            cargarGraficos();
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
                GestorCriterio gestor = new GestorCriterio();
                gestor.eliminarCriterioPorId();
                cargarRepeater();
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
            GestorCriterio gestor = new GestorCriterio();
            if (gestor.obtenerCantCriteriosPorProyecto() > 0)
                Response.Redirect("variables.aspx");
            else
            {
                mostrarError();
                litError.Text = "Debe cargar al menos un criterio!";
            }
        }

        //-------------------------------------------------
        //----------Metodos Auxiliares---------------------
        //-------------------------------------------------
        private void mostrarError()
        {
            panFracaso.Visible = true;
            litError.Visible = true;
        }
        protected void reestablecerPantalla()
        {
            panFracaso.Visible = false;
            Session["criterio"] = null;
            txtNombre.Value = "";
            txtAbreviacion.Value = "";
            txtColor.Value = "#E1E1E1";
            txtPeso.Value = "";
            //ddlTipoCriterio.SelectedValue = "0";
            btnAgregar.Visible = true;
            btnModificar.Visible = false;
            btnCancelar.Visible = false;
        }
        protected void cargarRepeater()
        {
            GestorCriterio gestor = new GestorCriterio();
            rptCriterios.DataSource = gestor.obtenerCriteriosPorProyectoTable();
            rptCriterios.DataBind();
            cargarGraficos();

        }
        private void cargarGraficos()
        {
            GestorCriterio gestor = new GestorCriterio();
            if (gestor.obtenerCantCriteriosPorProyecto() > 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "pesos", "drawPesos(" + gestor.obtenerGraficoPesos() + ");", true);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "pesosRelativos", "drawPesosRelativos(" + gestor.obtenerGraficoPesosRelativos() + ");", true);
            }
        }

        //protected string obtenerTipoCriterio(Object esTipoMax)
        //{
        //    if ((bool)esTipoMax)
        //        return "Max";
        //    return "Min";
        //}
    }
}