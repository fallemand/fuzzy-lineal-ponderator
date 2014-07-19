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
    public partial class mis_proyectos : System.Web.UI.Page
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
                GestorProyecto gestor = new GestorProyecto();
                gestor.registrarProyecto(txtNombre.Value);
                Response.Redirect("criterios.aspx");
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
                if (e.CommandName == "seleccionar")
                {
                    GestorProyecto gestor = new GestorProyecto();
                    Proyecto proyecto = gestor.obtenerProyectoPorId(int.Parse(e.CommandArgument.ToString()));
                    Session["proyecto"] = proyecto;
                    Response.Redirect("criterios.aspx");
                }
                if (e.CommandName == "editar")
                {
                    btnAgregar.Visible = false;
                    btnModificar.Visible = true;
                    btnCancelar.Visible = true;
                    GestorProyecto gestor = new GestorProyecto();
                    Proyecto proyecto = gestor.obtenerProyectoPorId(int.Parse(e.CommandArgument.ToString()));
                    Session["proyecto"] = proyecto;
                    txtNombre.Value = proyecto.nombre;
                }
                if (e.CommandName == "eliminar")
                {
                    GestorProyecto gestor = new GestorProyecto();
                    Proyecto proyecto = gestor.obtenerProyectoPorId(int.Parse(e.CommandArgument.ToString()));
                    Session["proyecto"] = proyecto;
                    litNombreProyecto.Text = proyecto.nombre;
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
                GestorProyecto gestor = new GestorProyecto();
                gestor.modificarProyecto(txtNombre.Value);
                cargarRepeater();
                reestablecerPantalla();
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
                GestorProyecto gestor = new GestorProyecto();
                gestor.eliminarProyectoPorId();
                cargarRepeater();
                reestablecerPantalla();
            }
            catch (Exception ex)
            {
                mostrarError();
                litError.Text = ex.Message;
            }
        }

        //-------------------------------------------------
        //----------Metodos Auxiliares---------------------
        //-------------------------------------------------
        protected void reestablecerPantalla()
        {
            panFracaso.Visible = false;
            Session["proyecto"] = null;
            txtNombre.Value = "";
            btnAgregar.Visible = true;
            btnModificar.Visible = false;
            btnCancelar.Visible = false;
        }
        private void mostrarError()
        {
            panFracaso.Visible = true;
            litError.Visible = true;
        }
        private void cargarRepeater()
        {
            GestorProyecto gestor = new GestorProyecto();
            rptProyectos.DataSource = gestor.obtenerTodosDataTable();
            rptProyectos.DataBind();
        }
    }
}