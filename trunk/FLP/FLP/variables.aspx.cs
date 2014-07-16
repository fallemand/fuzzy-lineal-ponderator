using Entidades;
using System;
using System.Collections.Generic;
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
            Proyecto proyecto = (Proyecto)Session["proyecto"];
            if (proyecto == null)
                Response.Redirect("mis-proyectos.aspx");
        }
    }
}