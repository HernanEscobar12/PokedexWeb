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
    public partial class Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!(Page is Login || Page is Registro || Page is Default))
            if (!(Seguridad.SessionActiva(Session["Trainee"])))
                Response.Redirect("Login.aspx", false);


            if (Seguridad.SessionActiva(Session["Trainee"]))

                imgAvatar.ImageUrl = "~/Images/" + ((Trainee)Session["Trainee"]).ImagenPerfil;
            else
                imgAvatar.ImageUrl = "https://img.freepik.com/premium-vector/user-profile-icon-flat-style-member-avatar-vector-illustration-isolated-background-human-permission-sign-business-concept_157943-15752.jpg?w=740";

        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx", false);
        }
    }
}