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
            if (!IsPostBack)
            {
                if (Session["Trainee"] != null)
                {
                    Trainee User = (Trainee)Session["Trainee"];
                    txtEmail.Text = User.Email;
                    txtEmail.ReadOnly = true;
                    txtNombre.Text = User.Nombre;
                    txtApellido.Text = User.Apellido;
                    txtFechaNacimiento.Text = User.FechaNacimiento.ToString("yyyy-MM-dd");
                    if (!string.IsNullOrEmpty(User.ImagenPerfil))
                        imgNuevoPerfil.ImageUrl = "~/Images/" + User.ImagenPerfil;
                }
            }


        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                TraineeNegocio Negocio = new TraineeNegocio();
                Trainee User = (Trainee)(Session["Trainee"]);

                //Escribir img

                if (txtImagen.PostedFile.FileName != "")
                {
                    string ruta = Server.MapPath("./Images/");
                    txtImagen.PostedFile.SaveAs(ruta + "Perfil" + User.Id + ".jpg");
                    User.ImagenPerfil = "Perfil" + User.Id + ".jpg";
                }

                //string ruta = Server.MapPath("./Images/");
                //txtImagen.PostedFile.SaveAs(ruta + "Perfil" + User.Id + ".jpg");
                //User.ImagenPerfil = "Perfil" + User.Id + ".jpg";

                User.Nombre = txtNombre.Text;
                User.Apellido = txtApellido.Text;
                User.FechaNacimiento = DateTime.Parse(txtFechaNacimiento.Text);
                Negocio.Actualizar(User);

                //leer img
                Image img = (Image)Master.FindControl("imgAvatar");
                img.ImageUrl = "~/Images/" + User.ImagenPerfil;

                Response.Redirect("MiPerfil.aspx", false);

            }
            catch (Exception Ex)
            {

                Session.Add("Error", Ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }


    }
}