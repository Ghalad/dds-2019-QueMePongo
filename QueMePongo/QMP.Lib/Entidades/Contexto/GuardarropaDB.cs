using Ar.UTN.QMP.Lib.Entidades.Atuendos;
using Ar.UTN.QMP.Lib.Entidades.Usuarios;
using System;
using System.Collections.Generic;

namespace Ar.UTN.QMP.Lib.Entidades.Contexto
{
    public class GuardarropaDB
    {
        public ICollection<Guardarropa> ObtenerGuardarropas(int userID)
        {
            using (QueMePongoDB db = new QueMePongoDB())
            {
                Usuario usr = db.Usuarios.Find(userID);
                db.Entry(usr).Collection(u => u.Guardarropas).Load();
                foreach (Guardarropa unGuardarropa in usr.Guardarropas)
                    db.Entry(unGuardarropa).Collection(g => g.Prendas).Load();

                return usr.Guardarropas;
            }
        }


        public void Crear(int userID, string nombre)
        {
            using (QueMePongoDB db = new QueMePongoDB())
            {
                Usuario usr = db.Usuarios.Find(userID);
                db.Entry(usr).Collection(u => u.Guardarropas).Load();

                // Esto lo requiere el enuncionado. No se si va a persistir de esta forma. Tal vez haya que hacerlo en el dominio como corresponde
                if (usr.Guardarropas.Count >= 2)
                    throw new Exception("Ya posee 2 guardarropas. No puede agregan nuevos guardarropas.");

                Guardarropa g = new Guardarropa(usr.MaximoPrendas);
                g.Nombre = nombre;
                usr.AgregarGuardarropa(g);
                
                db.SaveChanges();
            }
        }
    }
}
