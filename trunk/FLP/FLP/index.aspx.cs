using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;

namespace FLP
{
    public partial class index1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(5000);
            try
            {
                ocultarPaneles();
                //Registro de usuario en bd
                GestorUsuario gestorUsuario = new GestorUsuario();
                string codigo = gestorUsuario.registrarUsuario(txtNombre.Value, txtEmail.Value, txtContrasenia.Value);

                //parámetros para mandar mail
                string ActivationUrl = string.Empty;
                string mail = txtEmail.Value;
                string cuerpo = string.Empty;
                ActivationUrl = Server.HtmlEncode("http://localhost:12434/admin/activar.usuario.aspx?UserCode=" + codigo);

                GestorMails gestorMail = new GestorMails();
                gestorMail.mandarMailActivacion(mail, "Activación de Cuenta", ActivationUrl);

                btnRegistrar.Enabled = false;
                panExito.Visible = true;
                litMensaje.Text = "<strong>Se registró exitosamente su usuario.</strong><br />Revise su casilla de correo para activar su cuenta";
            }
            catch (Exception ex)
            {
                panFracaso.Visible = true;
                litError.Text = ex.Message;
            }
        }

        private void ocultarPaneles()
        {
            panExito.Visible = false;
            panFracaso.Visible = false;
        }
        
    }
}