using Ar.UTN.QMP.Lib.Entidades.Calificaciones;
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
        public bool? Aceptado { get; set; }
        public Calificacion Calificacion { get; set; }
        public ICollection<Prenda> Prendas { get; set; }

        public Atuendo()
        {
            this.Prendas = new HashSet<Prenda>();
            this.Aceptado = null;
            this.Calificacion = null;
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
        /// Marca al atuendo como aceptado
        /// </summary>
        public void Aceptar(int puntaje)
        {
            this.Aceptado = true;
            if (Calificacion == null)
                Calificacion = new Calificacion(puntaje);
            else
                this.Calificacion.Calificar(puntaje);

            foreach(Prenda unaPrenda in this.Prendas) 
            {
                unaPrenda.MarcarComoUsada();
                unaPrenda.Puntuar(puntaje); //se marca a cada prenda con el puntaje del atuendo.. no está bueno
            }
        }

        /// <summary>
        /// Marca al atuendo como rechazado
        /// </summary>
        public void Rechazar()
        {
            this.Aceptado = false;
        }

        /// <summary>
        /// Deshace la ultima operacion
        /// </summary>
        public void Deshacer()
        {
            this.Aceptado = null;
        }

        /// <summary>
        /// Se considera como mayor puntaje el de las prendas o el del atuendo
        /// </summary>
        /// <returns></returns>
        internal int ObtenerPuntaje()
        {
            int puntajeAtuendo = 0;
            int puntajePorPrendas = 0;
            if (this.Calificacion != null)
                puntajeAtuendo = this.Calificacion.ObtenerPuntaje() * this.CantidadDePrendas();
                
            // ^ suponiendo que el puntaje del atuendo es el promedio del de las prendas

            foreach (Prenda unaPrenda in this.Prendas)
                puntajePorPrendas = puntajePorPrendas + unaPrenda.ObtenerPuntaje();

            if(puntajePorPrendas > puntajeAtuendo)
                return puntajePorPrendas;
            else
                return puntajeAtuendo;
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
