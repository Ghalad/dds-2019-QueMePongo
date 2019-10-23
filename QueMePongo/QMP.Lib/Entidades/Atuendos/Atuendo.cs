using Ar.UTN.QMP.Lib.Entidades.Calificaciones;
using Ar.UTN.QMP.Lib.Entidades.Usuarios;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ar.UTN.QMP.Lib.Entidades.Atuendos
{
    [Table("Atuendos")]
    public class Atuendo
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AtuendoId { get; set; }
        public bool Aceptado { get; set; }
        public ICollection<Prenda> Prendas { get; set; }

        public Atuendo()
        {
            this.Prendas = new List<Prenda>();
            this.Aceptado = false;
        }

        /// <summary>
        /// Permite agregar prendas para formar el atuendo
        /// </summary>
        /// <param name="prenda"></param>
        public void AgregarPrenda(Prenda prenda)
        {
            if (prenda != null)
                this.Prendas.Add(prenda);
            else
                throw new Exception("No pueden agregarse prendas nulas al atuendo.");
        }

        /// <summary>
        /// Obtiene la cantidad de prendas que conforman el atuendo
        /// </summary>
        /// <returns></returns>
        public int CantidadDePrendas()
        {
            return this.Prendas.Count;
        }

        /// <summary>
        /// Marca al atuendo como aceptado y puntua todas las prendas que lo componen
        /// </summary>
        public void Aceptar(Usuario usuario, int puntaje)
        {
            if (this.Aceptado == false)
            {
                this.Aceptado = true;

                foreach (Prenda unaPrenda in this.Prendas)
                {
                    unaPrenda.MarcarComoUsada();
                    unaPrenda.Puntuar(usuario, puntaje);
                }
            }
            else
                throw new Exception("El Atuendo contiene prendas utilizadas por otro usuario.");
        }

        /// <summary>
        /// Deshace la ultima puntuacion y quita la marca de aceptado
        /// </summary>
        public void Deshacer()
        {
            this.Aceptado = false;
            // quitar calificacion
        }

        /// <summary>
        /// Obtiene el puntje de todas las prendas
        /// </summary>
        /// <returns></returns>
        internal int ObtenerPuntaje()
        {
            int puntaje = 0;
            foreach(Prenda unaPrenda in this.Prendas)
                puntaje += unaPrenda.ObtenerPuntaje();

            return puntaje;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        internal bool TienePrendasUsadas()
        {
            foreach(Prenda unaPrenda in this.Prendas)
                if (unaPrenda.EstaEnUso())
                    return true;
            return false;
        }

        /// <summary>
        /// Obtiene el nivel de abrigo de todas las prendas del atuendo que pertenescan a la categoria solicitada
        /// </summary>
        /// <param name="tipo"></param>
        /// <returns></returns>
        public int NivelDeAbrigoPorCategoria(string tipo)
        {
            int abrigo = 0;
            foreach (Prenda unaPrenda in this.Prendas)
                if(unaPrenda.TieneCaracteristica("CATEGORIA", tipo))
                    abrigo += Int32.Parse(unaPrenda.ObtenerCaracteristica("ABRIGO"));
            return abrigo;
        }
    }
}
