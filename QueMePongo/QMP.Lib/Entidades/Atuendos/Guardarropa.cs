using Ar.UTN.QMP.Lib.Entidades._0_ParaDB;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Ar.UTN.QMP.Lib.Entidades.Atuendos
{
    [Table("Guardarropas")]
    public class Guardarropa
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public ICollection<PrendaGuardarropa> Prendas { get; set; }
        public int MaximoPrendas { get; set; }

        public Guardarropa(int id, int maximoPrendas)
        {
            this.Id = id;
            this.MaximoPrendas = maximoPrendas;
            this.Prendas = new List<PrendaGuardarropa>();
        }
        

        /// <summary>
        /// Agrega Prendas al guardarropas. Si el guardarropas pertenece a un usuario Gratuito, agregara la prenda siempre y cuando tenga cupo.
        /// </summary>
        /// <param name="prenda"></param>
        public void AgregarPrenda(PrendaGuardarropa prenda)
        {
            if (this.MaximoPrendas == 0)
                this.Prendas.Add(prenda);
            else if (this.Prendas.Count < this.MaximoPrendas)
                this.Prendas.Add(prenda);
            else
                throw new Exception("Guardarropas lleno. No se pueden agregar mas prendas");
        }

        /// <summary>
        /// Obtiene la lista de prendas del guardarropas
        /// </summary>
        /// <returns></returns>
        public List<PrendaGuardarropa> ObtenerPrendas()
        {
            return this.Prendas.ToList();
        }
    }
}
