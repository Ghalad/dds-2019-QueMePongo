using Ar.UTN.QMP.Lib.Entidades.Usuarios;
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
        public int MaximoPrendas { get; set; }
        public ICollection<Usuario> Usuarios { get; set; }
        public ICollection<Prenda> Prendas { get; set; }

        public Guardarropa(int maximoPrendas)
        {
            this.Usuarios = new HashSet<Usuario>();
            this.MaximoPrendas = maximoPrendas;
            this.Prendas = new List<Prenda>();
        }

        private Guardarropa() { }
        

        /// <summary>
        /// Agrega Prendas al guardarropas. Si el guardarropas pertenece a un usuario Gratuito, agregara la prenda siempre y cuando tenga cupo.
        /// </summary>
        /// <param name="prenda"></param>
        public void AgregarPrenda(Prenda prenda)
        {
            if (this.MaximoPrendas == 0)
            {
                Prendas = new List<Prenda>();
                prenda.AgregarGuardarropa(this);
                this.Prendas.Add(prenda);
            }
            else if (this.Prendas.Count < this.MaximoPrendas)
            {

                prenda.AgregarGuardarropa(this);
                this.Prendas.Add(prenda);
            }
            else
                throw new Exception("Guardarropas lleno. No se pueden agregar mas prendas");
        }

        public void AgregarUsuario(Usuario usuario)
        {
            this.Usuarios.Add(usuario);
        }

        /// <summary>
        /// Obtiene la lista de prendas del guardarropas
        /// </summary>
        /// <returns></returns>
        public List<Prenda> ObtenerPrendas()
        {
            return this.Prendas.ToList();
        }
    }
}
