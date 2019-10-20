using Ar.UTN.QMP.Lib.Entidades.Reglas;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ar.UTN.QMP.Lib.Entidades.Atuendos
{
    [Table("Caracteristicas")]
    public class Caracteristica
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 1)]
        public int CaracteristicaId { get; private set; }
        [MaxLength(100)]
        public string Nombre { get; private set; }
        [MaxLength(50)]
        public string Clave { get; private set; }
        [MaxLength(50)]
        public string Valor { get; set; }
        public ICollection<Prenda> Prendas { get; set; } // Necesario para generar la relacion many-to-many
        public ICollection<Condicion> Condiciones { get; set; } // Necesario para generar la relacion many-to-many


        public Caracteristica() { }


        public Caracteristica(string clave, string valor)
        {
            if (!string.IsNullOrWhiteSpace(clave) || !string.IsNullOrWhiteSpace(valor))
            {
                this.Nombre = "CARACTERISTICA";
                this.Clave = clave.ToUpper();
                this.Valor = valor.ToUpper();
            }
            else
                throw new Exception("No se puede instanciar una caracteristica con clave o valor nulos.");
        }

        public Caracteristica(string nombre, string clave, string valor)
        {
            if(!string.IsNullOrWhiteSpace(nombre) || !string.IsNullOrWhiteSpace(clave) || !string.IsNullOrWhiteSpace(valor))
            {
                this.Nombre = nombre.ToUpper();
                this.Clave = clave.ToUpper();
                this.Valor = valor.ToUpper();
            }
            else
                throw new Exception("No se puede instanciar una caracteristica con nombre, clave o valor nulos.");
        }


        /// <summary>
        /// Valida si es la misma caracteristica, a traves de un objeto Caracteristica
        /// </summary>
        /// <param name="caracteristica"></param>
        /// <returns></returns>
        public bool EsLaMisma(Caracteristica caracteristica)
        {
            if (this.Clave.Equals(caracteristica.Clave) && this.Valor.Equals(caracteristica.Valor))
                return true;
            return false;
        }

        /// <summary>
        /// Valida si es la misma caracteristica, a traves de un par Clave, Valor
        /// </summary>
        /// <param name="clave"></param>
        /// <param name="valor"></param>
        /// <returns></returns>
        public bool EsLaMisma(string clave, string valor)
        {
            if (!string.IsNullOrWhiteSpace(clave) || !string.IsNullOrWhiteSpace(valor))
                if (this.Clave.Equals(clave.ToUpper()) && this.Valor.Equals(valor.ToUpper()))
                    return true;
            return false;
        }

        /// <summary>
        /// Valida si tiene la misma Clave
        /// </summary>
        /// <param name="clave"></param>
        /// <returns></returns>
        public bool EsLaMismaClave(string clave)
        {
            if (!string.IsNullOrWhiteSpace(clave))
                if (this.Clave.Equals(clave.ToUpper()))
                    return true;
            return false;
        }
    }
}
