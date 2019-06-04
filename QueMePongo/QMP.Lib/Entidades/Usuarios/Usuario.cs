using Ar.UTN.QMP.Lib.Entidades.Atuendos;
using Ar.UTN.QMP.Lib.Entidades.Guardaropa;
using System.Collections.Generic;

namespace Ar.UTN.QMP.Lib.Entidades.Usuarios
{
    public class Usuario
    {
        public List<Guardarropa> Guardarropas { get; set; }

        public Usuario()
        {
            this.Guardarropas = new List<Guardarropa>();
        }

        public void CrearGuardarropa(string id)
        {
            this.Guardarropas.Add(new Guardarropa(id));
        }



        public Atuendo ObtenerAtuendo(string guardarropa)
        {
            return this.Guardarropas.Find(g => g.Id.Equals(guardarropa)).ObtenerAtuendo();
        }


        public void AgregarPrenda(string guardarropa, Prenda prenda)
        {
            this.Guardarropas.Find(g => g.Id.Equals(guardarropa)).Prendas.Add(prenda);
        }
        
    }
}
