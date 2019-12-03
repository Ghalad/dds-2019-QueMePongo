using Ar.UTN.QMP.Lib.Entidades.Usuarios;
using System;
using System.Linq;

namespace Ar.UTN.QMP.Lib.Entidades.Contexto
{
    public class UsuarioDB
    {
        public int LogIn(string usuario, string password)
        {
            using (QueMePongoDB db = new QueMePongoDB())
            {
                Usuario usr = db.Usuarios.Where(u => u.Username.Equals(usuario)).FirstOrDefault();

                if (usr == null)  // usuario nuevo
                {
                    usr = new UsrGratis(10, usuario);
                    usr.Password = password;
                    db.Usuarios.Add(usr);
                    db.SaveChanges();
                    return usr.UsuarioId;
                }
                else // usuario existente
                {
                    if (!password.Equals(usr.Password))
                        throw new Exception("La contraseña ingresada es incorrecta.");
                    else
                        return usr.UsuarioId;
                }
            }
        }

        public Usuario ObtenerUsuario(int usrID)
        {
            using (QueMePongoDB db = new QueMePongoDB())
            {
                return db.Usuarios.Find(usrID);
            }
        }

        public void Modificar(int userID, int sensibilidad, string tarjetaDeCredito)
        {
            using (QueMePongoDB db = new QueMePongoDB())
            {
                Usuario usr = db.Usuarios.Find(userID);

                if (usr != null)
                {
                    usr.Sensibilidad = sensibilidad;
                    if (usr.GetType() == typeof(UsrPremium))
                    {
                        ((UsrPremium)usr).TarjetaCredito = tarjetaDeCredito;
                    }
                }
                else
                {
                    throw new Exception("El usuario no existe.");
                }


                db.SaveChanges();
            }
        }
    }
}
