using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class TraineeNegocio
    {
        //id
        //email
        //pass
        //admin false

        //nombre, apellido, fecha, imagen

        public int InsertarNuevo(Trainee nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearProcedimiento("insertarNuevo");
                datos.SetearParametro("@email", nuevo.Email);
                datos.SetearParametro("@pass", nuevo.Pass);
                return datos.EjecutarAccionScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }

        }

        public void Actualizar(Trainee user)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta("Update USERS set imagenPerfil = @imagen, Nombre = @nombre, Apellido = @apellido, fechaNacimiento = @fecha Where Id = @id");
                //datos.setearParametro("@imagen", user.ImagenPerfil != null ? user.ImagenPerfil : (object)DBNull.Value);
                datos.SetearParametro("@imagen", (object)user.ImagenPerfil ?? DBNull.Value);
                datos.SetearParametro("@nombre", user.Nombre);
                datos.SetearParametro("@apellido", user.Apellido);
                datos.SetearParametro("@fecha", user.FechaNacimiento);
                datos.SetearParametro("@id", user.Id);
                datos.EjecutarAccion();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }

        public bool Login(Trainee trainee)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta("Select id, email, pass, admin, imagenPerfil, nombre, apellido, fechaNacimiento from USERS Where email = @email And pass = @pass");
                datos.SetearParametro("@email", trainee.Email);
                datos.SetearParametro("@pass", trainee.Pass);
                datos.EjecutarLectura();
                if (datos.Lector.Read())
                {
                    trainee.Id = (int)datos.Lector["id"];
                    trainee.Admin = (bool)datos.Lector["admin"];
                    if (!(datos.Lector["imagenPerfil"] is DBNull))
                        trainee.ImagenPerfil = (string)datos.Lector["imagenPerfil"];
                    if (!(datos.Lector["nombre"] is DBNull))
                        trainee.Nombre = (string)datos.Lector["nombre"];
                    if (!(datos.Lector["apellido"] is DBNull))
                        trainee.Apellido = (string)datos.Lector["apellido"];
                    if (!(datos.Lector["fechaNacimiento"] is DBNull))
                        trainee.FechaNacimiento = DateTime.Parse(datos.Lector["fechaNacimiento"].ToString());

                    return true;
                }
                return false;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }


    }
}
