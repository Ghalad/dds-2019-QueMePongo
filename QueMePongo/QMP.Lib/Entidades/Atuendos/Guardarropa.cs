using System;
using System.Collections.Generic;

namespace Ar.UTN.QMP.Lib.Entidades.Atuendos
{
    public class Guardarropa
    {
        public string Id { get; set; }
        private List<Prenda> Prendas { get; set; }
        private int MaximoPrendas { get; set; }

        public Guardarropa(string id, int maximoPrendas)
        {
            this.Id = id;
            this.MaximoPrendas = maximoPrendas;
            this.Prendas = new List<Prenda>();
        }
        

        /// <summary>
        /// Agrega Prendas al guardarropas.
        /// Si el guardarropas pertenece a un usuario Gratuito, agregara la prenda siempre y cuando tenga cupo.
        /// </summary>
        /// <param name="prenda"></param>
        public void AgregarPrenda(Prenda prenda)
        {
            if (this.MaximoPrendas == 0)
                this.Prendas.Add(prenda);
            else if (this.Prendas.Count < this.MaximoPrendas)
                this.Prendas.Add(prenda);
            else
                throw new Exception("Guardarropas lleno. No se pueden agregar mas prendas");
        }


        public List<Prenda> ObtenerPrendas()
        {
            return this.Prendas;
        }
    }
}
