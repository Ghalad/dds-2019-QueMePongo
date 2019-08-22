using Ar.UTN.QMP.Lib.Entidades.Calificaciones;
using System;
using System.Collections.Generic;

namespace Ar.UTN.QMP.Lib.Entidades.Atuendos
{
    public class Atuendo
    {
        public string Id { get; set; }
        public List<Prenda> Prendas { get; set; }
        private bool? Aceptado { get; set; }
        public Calificacion Calificacion { get; set; }

        public Atuendo()
        {
            this.Prendas = new List<Prenda>();
            this.Aceptado = null;
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
        public void Aceptar()
        {
            this.Aceptado = true;
            foreach(Prenda p in Prendas)
            {
                p.MarcarComoUsada();
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

        internal int ObtenerPuntaje()
        {
            int puntajePorPrendas = 0;
            int puntajeAtuendo = this.Calificacion.ObtenerPuntaje() * this.CantidadDePrendas();
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

        internal int NivelDeAbrigo()
        {
            int suma = 0;
            int valorAux;

            foreach(Prenda p in Prendas)
            {
                valorAux = Tipos.GetInstance().ObtenerNivelDeAbrigo(p.ObtenerCaracteristica("TIPO"));
                suma = suma + valorAux;
            }

            return suma;
        }
    }
}
