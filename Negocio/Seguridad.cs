using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Negocio
{
    public static class Seguridad
    {
        public static bool SessionActiva(object user)
        {
            Trainee trainee = user != null ? (Trainee) user : null;
            if (trainee != null && trainee.Id != 0)
                return true;
            else 
                return false;

        }

    }
}
