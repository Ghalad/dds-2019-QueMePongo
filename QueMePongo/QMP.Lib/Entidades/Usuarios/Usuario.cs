using Ar.UTN.QMP.Lib.Entidades.Atuendos;
using Ar.UTN.QMP.Lib.Entidades.Guardaropa;
using System.Collections.Generic;

namespace Ar.UTN.QMP.Lib.Entidades.Usuarios
{
    public class Usuario
    {
        public string User { get; set; }
        public string Pass { get; set; }
        public List<Guardarropa> Guardarropas { get; set; }

        public Usuario()
        {
            this.Guardarropas = new List<Guardarropa>();
        }


        /// <summary>
        /// Solicita un <see cref="Atuendo"/> a un <see cref="Guardarropa"/> determinado
        /// </summary>
        /// <param name="guardarropa"></param>
        /// <returns></returns>
        public Atuendo ObtenerAtuendo(string guardarropa)
        {
            return this.Guardarropas.Find(g => g.Id.Equals(guardarropa)).ObtenerAtuendo();
        }

        /// <summary>
        /// Agregar una <see cref="Prenda"/> a un <see cref="Guardarropa"/> determinado
        /// </summary>
        /// <param name="prenda"></param>
        /// <param name="guardarropa"></param>
        public void AgregarPrenda(Prenda prenda, string guardarropa)
        {
            this.Guardarropas.Find(g => g.Id.Equals(guardarropa)).AgregarPrenda(prenda);
        }
    }
}
