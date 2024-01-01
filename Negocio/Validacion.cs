using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace Negocio
{
    public static class Validacion
    {
        public static bool ValidaTextoVacio(object control)
        {
            if(control is TextBox Texto)
            {
                if (string.IsNullOrEmpty(Texto.Text))
                    return false;
                else
                    return true;
            }

            return false;
        }
    }
}
