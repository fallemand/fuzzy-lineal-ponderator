using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;

namespace FLP
{
    public partial class criterios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try 
	        {
                litError.Visible = false;
		        GestorCriterio gestor = new GestorCriterio();
                gestor.registrarCriterio(txtNombre.Value, txtAbreviacion.Value, int.Parse(txtPeso.Value), txtColor.Value);
	        }
	        catch (Exception ex)
	        {
                litError.Visible = true;
                litError.Text = "<span class='help-block'>" + ex.Message + "</span>";
	        }
        }
    }
}