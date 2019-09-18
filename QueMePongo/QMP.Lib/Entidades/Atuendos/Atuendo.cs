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
        [Key]
        public int Id { get; set; }
        public List<Prenda> Prendas { get; set; }
        private bool? Aceptado { get; set; }
        public Calificacion Calificacion { get; set; }

        public Atuendo()
        {
            this.Prendas = new List<Prenda>();
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
            foreach(Prenda p in Prendas) 
            {
                p.MarcarComoUsada();
                p.Puntuar(puntaje); //se marca a cada prenda con el puntaje del atuendo.. no está bueno
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

            foreach (Prenda p in this.Prendas)
            {
                puntajePorPrendas = puntajePorPrendas + p.ObtenerPuntaje();
            }

            if(puntajePorPrendas > puntajeAtuendo)
            {
                return puntajePorPrendas;
            }
            else
            {
                return puntajeAtuendo;
            }
        }

        internal bool TienePrendasUsadas()
        {
            foreach(Prenda p in Prendas)
            {
                if (p.EstaEnUso())
                {
                    return true;
                }
            }
            return false;
        }

        public int AbrigoCategoria(string tipo)
        {
            foreach (Prenda p in Prendas)
            {
                if(p.TieneCaracteristica(new Caracteristica("CATEGORIA", tipo)))
                {
                    return Int32.Parse(p.ObtenerCaracteristica("ABRIGO"));
                }
            }
            return 0;
        }

        [Obsolete]
        internal int NivelDeAbrigo()
        {
            int suma = 0;
            int valorAux;

            foreach(Prenda p in Prendas)
            {
                valorAux = Convert.ToInt32(Tipos.GetInstance().ObtenerAbrigo(p.ObtenerCaracteristica("TIPO")));
                suma = suma + valorAux;
            }

            return suma;
        }
    }
}
