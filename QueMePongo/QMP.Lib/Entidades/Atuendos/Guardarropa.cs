﻿using Ar.UTN.QMP.Lib.Entidades.Usuarios;
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
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GuardarropaId { get; set; }
        public string Nombre { get; set; }
        public int MaximoPrendas { get; set; }
        public ICollection<Prenda> Prendas { get; set; }
        public ICollection<Usuario> Usuarios { get; set; }


        private Guardarropa()
        {
            this.Prendas = new List<Prenda>();
        }

        public Guardarropa(int maximoPrendas)
        {
            this.Usuarios = new List<Usuario>();
            this.Prendas = new List<Prenda>();
            this.MaximoPrendas = maximoPrendas;
        }
        

        /// <summary>
        /// Agrega Prendas al guardarropas. Si el guardarropas pertenece a un usuario Gratuito, agregara la prenda siempre y cuando tenga cupo.
        /// </summary>
        /// <param name="prenda"></param>
        public void AgregarPrenda(Prenda prenda)
        {
            if (this.Prendas != null)
            {
                if (this.MaximoPrendas == 0)
                {
                    this.Prendas.Add(prenda);
                }
                else if (this.Prendas.Count < this.MaximoPrendas)
                {
                    this.Prendas.Add(prenda);
                }
                else
                    throw new Exception("Guardarropas lleno. No se pueden agregar mas prendas");
            }
            else
                throw new Exception("La lista de prendas no esta inicilizada.");
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
