using Ar.UTN.QMP.Lib.Entidades.Atuendos;
using Ar.UTN.QMP.Lib.Entidades.Reglas;
using System;
using System.Collections.Generic;

namespace Ar.UTN.QMP.Lib.Entidades.Core
{
    public class Pedido
    {
        public string Id { get; set; }
        private List<Prenda> Prendas { get; set; }
        private List<Regla> Reglas { get; set; }
        private List<Atuendo> Atuendos { get; set; }

        public Pedido(List<Prenda> prendas, List<Regla> reglas)
        {
            if (prendas != null)
                this.Prendas = prendas;
            else
                throw new Exception("Es necesario una lista de prendas");

            if (reglas != null)
                this.Reglas = reglas;
            else
                throw new Exception("Es necesario una lista de reglas");

            this.Atuendos = new List<Atuendo>();
            this.Id = "12345"; // generar ID
        }

        /// <summary>
        /// Resuelve el pedido, generando un atuendo y haciendolo disponible para que el usuario lo obtenga previa notificacion
        /// </summary>
        public void Resolver()
        {
            this.CombinarPrendas();
            this.FiltrarPorReglas();
            this.FiltrarPorClima();
            this.FiltrarPorEvento();
        }

        /// <summary>
        /// Obtiene un atuendo que no haya sido marcado antes
        /// </summary>
        /// <returns></returns>
        public List<Atuendo> ObtenerAtuendos()
        {
            return this.Atuendos;
        }

        /// <summary>
        /// Setea una coleccion de Atuendos con todas las combinaciones de prendas posibles.
        /// Formula de combinaciones:
        /// n! / (r!(n-r)!)
        /// </summary>
        /// <param name="n"></param>
        private void CombinarPrendas()
        {
            Atuendo atuendo;
            int max = this.Prendas.Count;

            // Se toma como minimo, combinaciones de 4 prendas ya que son las 3 partes del cuerpo que tienen que estar cubiertas siempre.
            for (int i = 3; i < max; i++)
            {
                foreach (var row in new Combinaciones.Combinaciones(this.Prendas.Count, i).GetRows())
                {
                    atuendo = new Atuendo();
                    foreach (var seleccion in Combinaciones.Combinaciones.Permute(row, this.Prendas))
                        atuendo.AgregarPrenda(seleccion);
                    this.Atuendos.Add(atuendo);
                }
            }
        }

        /// <summary>
        /// Aplica todas las reglas a la lista de atuendos, quitando los que no son validos.
        /// </summary>
        private void FiltrarPorReglas()
        {
            bool atuendoValido = false;

            if (this.Atuendos != null)
            {
                foreach (Atuendo atuendo in this.Atuendos)
                {
                    foreach (Regla regla in this.Reglas)
                    {
                        if (regla.Validar(atuendo))
                            atuendoValido = true;
                        else
                        {
                            atuendoValido = false;
                            break;
                        }
                    }

                    if (!atuendoValido)
                        this.Atuendos.Remove(atuendo); // Atuendo invalido, lo saco de la lista de atuendos
                }
            }
            else
                throw new Exception("No es posible aplicar reglas a una lista de atuendos nula.");
        }

        private void FiltrarPorClima()
        {

        }

        private void FiltrarPorEvento()
        {

        }
    }
}
