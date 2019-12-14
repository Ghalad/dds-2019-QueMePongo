using Ar.UTN.QMP.Lib.Entidades.Atuendos;
using Ar.UTN.QMP.Lib.Entidades.Reglas;
using Ar.UTN.QMP.Lib.Entidades.Reglas.Condiciones;
using Ar.UTN.QMP.Lib.Entidades.Reglas.Operadores;
using Ar.UTN.QMP.Lib.Entidades.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ar.UTN.QMP.Lib.Entidades.Contexto
{
    public class UsuarioDB
    {
        public int LogIn(string userName, string password, bool esPremium, string tarjetaCredito)
        {
            using (QueMePongoDB db = new QueMePongoDB())
            {
                Usuario usr = db.Usuarios.Where(u => u.Username.Equals(userName)).FirstOrDefault();

                if (usr == null)  // usuario nuevo
                {
                    if (esPremium)
                    {
                        usr = new UsrPremium(userName);
                        ((UsrPremium)usr).TarjetaCredito = tarjetaCredito;
                    }
                    else
                    {
                        usr = new UsrGratis(10, userName);
                    }
                    usr.Password = password;

                    db.Usuarios.Add(usr);
                    db.SaveChanges();

                    this.AsignarReglasComunes(usr.UsuarioId);

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


        public Usuario Cargar(int userID)
        {
            using (QueMePongoDB db = new QueMePongoDB())
            {
                var user = db.Usuarios.Find(userID);
                db.Entry(user).Collection(u => u.Guardarropas).Load();
                db.Entry(user).Collection(u => u.Reglas).Load();
                foreach (Guardarropa guardarropa in user.Guardarropas)
                {
                    db.Entry(guardarropa).Collection(g => g.Prendas).Load();
                    foreach (Prenda prenda in guardarropa.Prendas)
                    {
                        db.Entry(prenda).Collection(p => p.Caracteristicas).Load();
                        db.Entry(prenda).Collection(p => p.Calificaciones).Load();
                    }
                }
                foreach (Regla regla in user.Reglas)
                {
                    db.Entry(regla).Collection(g => g.Condiciones).Load();
                    foreach (Condicion condicion in regla.Condiciones)
                    {
                        db.Entry(condicion).Collection(c => c.Caracteristicas).Load();
                        if (condicion.GetType() == typeof(CondicionCantidad))
                        {
                            db.Entry((CondicionCantidad)condicion).Reference(c => c.Operador).Load();
                        }
                    }
                }
                return user;
            }
        }


        private void AsignarReglasComunes(int userID)
        {
            Regla r1;
            List<Caracteristica> listaCar;
            Usuario user;


            using (QueMePongoDB db = new QueMePongoDB())
            {
                user = db.Usuarios.Find(userID);
                
                // descarta los atuendos que tengan en la parte superior mas de una prenda con nivel de superposicion 1
                r1 = new Regla();
                listaCar = new List<Caracteristica>();
                listaCar.Add(db.Caracteristicas.Where(c => c.Nombre == "CARACTERISTICA" && c.Clave == "CATEGORIA" && c.Valor == "SUPERIOR").FirstOrDefault());
                listaCar.Add(db.Caracteristicas.Where(c => c.Nombre == "CARACTERISTICA" && c.Clave == "SUPERPOSICION" && c.Valor == "1").FirstOrDefault());
                r1.AgregarCondicion(new CondicionCantidad(new OperadorMayor(1), listaCar));
                user.AgregarRegla(r1);

                // descarta los atuendos que tengan en la parte superior mas de una prenda con nivel de superposicion 2
                r1 = new Regla();
                listaCar = new List<Caracteristica>();
                listaCar.Add(db.Caracteristicas.Where(c => c.Nombre == "CARACTERISTICA" && c.Clave == "CATEGORIA" && c.Valor == "SUPERIOR").FirstOrDefault());
                listaCar.Add(db.Caracteristicas.Where(c => c.Nombre == "CARACTERISTICA" && c.Clave == "SUPERPOSICION" && c.Valor == "2").FirstOrDefault());
                r1.AgregarCondicion(new CondicionCantidad(new OperadorMayor(1), listaCar));
                user.AgregarRegla(r1);

                // descarta los atuendos que tengan en la parte superior mas de una prenda con nivel de superposicion 3
                r1 = new Regla();
                listaCar = new List<Caracteristica>();
                listaCar.Add(db.Caracteristicas.Where(c => c.Nombre == "CARACTERISTICA" && c.Clave == "CATEGORIA" && c.Valor == "SUPERIOR").FirstOrDefault());
                listaCar.Add(db.Caracteristicas.Where(c => c.Nombre == "CARACTERISTICA" && c.Clave == "SUPERPOSICION" && c.Valor == "3").FirstOrDefault());
                r1.AgregarCondicion(new CondicionCantidad(new OperadorMayor(1), listaCar));
                user.AgregarRegla(r1);

                // descarta los atuendos que tengan en la parte superior mas de una prenda con nivel de superposicion 4
                r1 = new Regla();
                listaCar = new List<Caracteristica>();
                listaCar.Add(db.Caracteristicas.Where(c => c.Nombre == "CARACTERISTICA" && c.Clave == "CATEGORIA" && c.Valor == "SUPERIOR").FirstOrDefault());
                listaCar.Add(db.Caracteristicas.Where(c => c.Nombre == "CARACTERISTICA" && c.Clave == "SUPERPOSICION" && c.Valor == "4").FirstOrDefault());
                r1.AgregarCondicion(new CondicionCantidad(new OperadorMayor(1), listaCar));
                user.AgregarRegla(r1);

                // descarta los atuendos que no tengan prendas en la parte superior
                r1 = new Regla();
                listaCar = new List<Caracteristica>();
                listaCar.Add(db.Caracteristicas.Where(c => c.Nombre == "CARACTERISTICA" && c.Clave == "CATEGORIA" && c.Valor == "SUPERIOR").FirstOrDefault());
                r1.AgregarCondicion(new CondicionCantidad(new OperadorIgual(0), listaCar));
                user.AgregarRegla(r1);

                // descarta los atuendos que no tengan prendas en la parte inferior
                r1 = new Regla();
                listaCar = new List<Caracteristica>();
                listaCar.Add(db.Caracteristicas.Where(c => c.Nombre == "CARACTERISTICA" && c.Clave == "CATEGORIA" && c.Valor == "INFERIOR").FirstOrDefault());
                r1.AgregarCondicion(new CondicionCantidad(new OperadorIgual(0), listaCar));
                user.AgregarRegla(r1);

                // descarta los atuendos que no tengan calzado
                r1 = new Regla();
                listaCar = new List<Caracteristica>();
                listaCar.Add(db.Caracteristicas.Where(c => c.Nombre == "CARACTERISTICA" && c.Clave == "CATEGORIA" && c.Valor == "CALZADO").FirstOrDefault());
                r1.AgregarCondicion(new CondicionCantidad(new OperadorIgual(0), listaCar));
                user.AgregarRegla(r1);

                // descarta los atuendos que tengan mas de 1 calzado
                r1 = new Regla();
                listaCar = new List<Caracteristica>();
                listaCar.Add(db.Caracteristicas.Where(c => c.Nombre == "CARACTERISTICA" && c.Clave == "CATEGORIA" && c.Valor == "CALZADO").FirstOrDefault());
                r1.AgregarCondicion(new CondicionCantidad(new OperadorMayor(1), listaCar));
                user.AgregarRegla(r1);

                db.SaveChanges();
            }
        }
    }
}
