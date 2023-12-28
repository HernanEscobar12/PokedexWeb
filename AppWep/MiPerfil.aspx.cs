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
                TraineeNegocio Negocio = new TraineeNegocio();

                //Escribir img
                string ruta = Server.MapPath("./Images/");
                Trainee User = (Trainee)(Session["Trainee"]);
                txtImagen.PostedFile.SaveAs(ruta + "Perfil" + User.Id + ".jpg");
                User.ImagenPerfil = "Perfil" + User.Id + ".jpg";
                User.Nombre = txtNombre.Text;
                User.Apellido = txtApellido.Text;
                User.FechaNacimiento = DateTime.Parse(txtFechaNacimiento.Text);
                Negocio.Actualizar(User);

                //leer img
                Image img = (Image)Master.FindControl("imgAvatar");
                img.ImageUrl = "~/Images/" + User.ImagenPerfil;



            }
            catch (Exception Ex)
            {

                Session.Add("Error", Ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}