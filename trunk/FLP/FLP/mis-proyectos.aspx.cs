using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;

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
                    GestorProyecto gestor = new GestorProyecto();
                    rptProyectos.DataSource = gestor.obtenerTodosDataTable();
                    rptProyectos.DataBind();
                }
                catch (Exception ex)
                {
                    //lblMensajeTorneos.Text = ex.Message;
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
                litError.Visible = true;
                litError.Text = "<span class='help-block'>" + ex.Message + "</span>";
            }
        }

        protected void rptProyectos_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }
    }
}