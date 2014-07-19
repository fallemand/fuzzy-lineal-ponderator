using Entidades;
using Logica;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FLP
{
    public partial class variables : System.Web.UI.Page
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
                GestorVariable gestor = new GestorVariable();
                gestor.registrarVariable(txtNombre.Value, txtAbreviacion.Value, txtColor.Value, decimal.Parse(txtA.Value, CultureInfo.InvariantCulture), decimal.Parse(txtB.Value, CultureInfo.InvariantCulture), decimal.Parse(txtC.Value, CultureInfo.InvariantCulture));
                reestablecerPantalla();
                cargarRepeater();
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
                GestorVariable gestor = new GestorVariable();
                gestor.modificarVariable(txtNombre.Value, txtAbreviacion.Value, txtColor.Value, decimal.Parse(txtA.Value, CultureInfo.InvariantCulture), decimal.Parse(txtB.Value, CultureInfo.InvariantCulture), decimal.Parse(txtC.Value, CultureInfo.InvariantCulture));
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
            cargarGrafico();
        }

        protected void rptProyectos_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            try
            {
                reestablecerPantalla();
                GestorVariable gestor = new GestorVariable();
                if (e.CommandName == "editar")
                {
                    int idVariable = int.Parse(e.CommandArgument.ToString());
                    Variable variable = gestor.obtenerVariablePorId(idVariable);
                    Session["variable"] = variable;
                    txtNombre.Value = variable.nombre;
                    txtAbreviacion.Value = variable.abreviacion;
                    txtColor.Value = variable.color;
                    txtA.Value = variable.a.ToString(CultureInfo.InvariantCulture);
                    txtB.Value = variable.b.ToString(CultureInfo.InvariantCulture);
                    txtC.Value = variable.c.ToString(CultureInfo.InvariantCulture);
                    btnAgregar.Visible = false;
                    btnModificar.Visible = true;
                    btnCancelar.Visible = true;
                }
                if (e.CommandName == "eliminar")
                {
                    Variable variable = gestor.obtenerVariablePorId(int.Parse(e.CommandArgument.ToString()));
                    Session["variable"] = variable;
                    litNombreVariable.Text = variable.nombre;
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

        protected void btnCancelarEliminacion_Click(object sender, EventArgs e)
        {
            reestablecerPantalla();
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "closeModalEliminar();", true);
                GestorVariable gestor = new GestorVariable();
                gestor.eliminarVariablePorId();
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
            GestorVariable gestor = new GestorVariable();
            if (gestor.obtenerCantVariablesPorProyecto() > 0)
                Response.Redirect("alternativas.aspx");
            else
            {
                mostrarError();
                litError.Text = "Debe cargar al menos una variable!";
            }
        }

        //-------------------------------------------------
        //----------Metodos Auxiliares---------------------
        //-------------------------------------------------
        protected void cargarRepeater()
        {
            GestorVariable gestor = new GestorVariable();
            rptVariables.DataSource = gestor.obtenerVariablesPorProyecto();
            rptVariables.DataBind();
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
            Session["variable"] = null;
            txtNombre.Value = "";
            txtAbreviacion.Value = "";
            txtColor.Value = "#E1E1E1";
            txtA.Value = "";
            txtB.Value = "";
            txtC.Value = "";
            btnAgregar.Visible = true;
            btnModificar.Visible = false;
            btnCancelar.Visible = false;
        }
        private void cargarGrafico()
        {
            GestorVariable gestor = new GestorVariable();
            if(gestor.obtenerCantVariablesPorProyecto() > 0)
                ScriptManager.RegisterStartupScript(this, this.GetType(), "variables", "drawVariables(" + gestor.obtenerGraficoVariables() + ");", true);
        }
    }
}