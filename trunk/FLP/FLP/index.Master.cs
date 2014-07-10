using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using Entidades;
using System.Web.Security;
using System.Web.UI.HtmlControls;

namespace FLP
{
    public partial class index : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["usuario"] != null)
                {
                    Usuario usuario = (Usuario)Session["usuario"];
                    Literal litNombre = (Literal)lvNavBar.FindControl("LitNombre");
                    litNombre.Text = usuario.nombre;
                }
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                Panel panFracasoLogin = (Panel)lvNavBar.FindControl("panFracasoLogin");
                panFracasoLogin.Visible = false;
                GestorUsuario gestorUsuario = new GestorUsuario();
                HtmlInputText txtEmailLogin = (HtmlInputText)lvNavBar.FindControl("txtEmailLogin");
                HtmlInputText txtContraseniaLogin = (HtmlInputText)lvNavBar.FindControl("txtContraseniaLogin");
                Usuario u = gestorUsuario.validarUsuario(txtEmailLogin.Value, txtContraseniaLogin.Value);
                Session["usuario"] = u;
                FormsAuthentication.RedirectFromLoginPage(txtEmailLogin.Value, true);
            }
            catch (Exception ex)
            {
                Panel drodownmenu = (Panel)lvNavBar.FindControl("drodownmenu");
                Panel panFracasoLogin = (Panel)lvNavBar.FindControl("panFracasoLogin");
                Literal litErrorLogin = (Literal)lvNavBar.FindControl("litErrorLogin");
                drodownmenu.Style.Add("display", "block");
                panFracasoLogin.Visible = true;
                litErrorLogin.Text = ex.Message;
            }
        }

        protected void hlCerrarSesion_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            FormsAuthentication.SignOut();
            Response.Redirect("index.aspx");
        }
    }
}