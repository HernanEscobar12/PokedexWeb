using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppWep
{
    public partial class MiPerfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            {
               

            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception Ex)
            {

                Session.Add("Error", Ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}