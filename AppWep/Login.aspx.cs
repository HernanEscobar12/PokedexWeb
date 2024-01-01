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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                TraineeNegocio Negocio = new TraineeNegocio();
                Trainee trainee = new Trainee();
                trainee.Email = txtEmail.Text;
                trainee.Pass = txtPassword.Text;
                if(Negocio.Login(trainee))
                {
                    Session.Add("Trainee", trainee);
                    Response.Redirect("Default.aspx", false);
                }
                else
                { 
                    Session.Add("Error", "Email o Pass Incorrectos");
                    Response.Redirect("Error.aspx", false);
                }
                

            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx");
                
            }
        }
    }
}