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
                    Proyecto proyecto = (Proyecto)Session["proyecto"];
                    if (proyecto == null)
                        Response.Redirect("mis-proyectos.aspx");
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
                gestor.registrarCriterio(txtNombre.Value, txtAbreviacion.Value, int.Parse(txtPeso.Value), txtColor.Value);
                cargarRepeater();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "limpiarCampos();", true);
	        }
	        catch (Exception ex)
	        {
                mostrarError();
                litError.Text = ex.Message;
	        }
        }

        protected void cargarRepeater()
        {
            GestorCriterio gestor = new GestorCriterio();
            rptProyectos.DataSource = gestor.obtenerCriteriosDelProyecto();
            rptProyectos.DataBind();
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
                    btnAgregar.Visible = false;
                    btnModificar.Visible = true;
                    btnCancelar.Visible = true;
                }
                if (e.CommandName == "eliminar")
                {
                    Criterio criterio = gestor.obtenerCriterioPorId(int.Parse(e.CommandArgument.ToString()));
                    Session["criterio"] = criterio;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalEliminar();", true);
                }
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
                gestor.modificarCriterio(txtNombre.Value, txtAbreviacion.Value, int.Parse(txtPeso.Value), txtColor.Value);
                reestablecerPantalla();
                cargarRepeater();
            }
            catch (Exception ex)
            {
                mostrarError();
                litError.Text = ex.Message;
            }
        }

        protected void reestablecerPantalla()
        {
            panFracaso.Visible = false;
            Session["criterio"] = null;
            txtNombre.Value = "";
            txtAbreviacion.Value = "";
            txtColor.Value = "#E1E1E1";
            txtPeso.Value = "";
            btnAgregar.Visible = true;
            btnModificar.Visible = false;
            btnCancelar.Visible = false;
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            reestablecerPantalla();
        }

        private void mostrarError()
        {
            panFracaso.Visible = true;
            litError.Visible = true;
        }

        protected void btnCancelarEliminacion_Click(object sender, EventArgs e)
        {
            reestablecerPantalla();
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                GestorCriterio gestor = new GestorCriterio();
                gestor.eliminarCriterioPorId();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "closeModalEliminar();", true);
                cargarRepeater();
                reestablecerPantalla();
            }
            catch (Exception ex)
            {
                mostrarError();
                litError.Text = ex.Message;
            }
        }

    }
}