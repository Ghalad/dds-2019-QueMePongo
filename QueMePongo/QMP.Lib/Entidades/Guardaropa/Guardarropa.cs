using Ar.UTN.QMP.Lib.Entidades.Atuendos;
using Ar.UTN.QMP.Lib.Entidades.Reglas;
using System;
using System.Collections.Generic;

namespace Ar.UTN.QMP.Lib.Entidades.Guardaropa
{
    public class Guardarropa
    {
        public string Id { get; set; }
        public List<Prenda> Prendas { get; set; }
        public List<Atuendo> Atuendos { get; set; }
        public List<Regla> Reglas { get; set; }

        public Guardarropa(string id)
        {
            this.Id = id;
            this.Atuendos = new List<Atuendo>();
            this.Reglas = new List<Regla>();
            this.Prendas = new List<Prenda>();
        }

        public void AgregarPrenda(Prenda prenda)
        {
            //TODO Faltaria agregar logica para limitar la insercion de prendas
            this.Prendas.Add(prenda);
        }

        /// <summary>
        /// Obtiene un <see cref="Atuendo"/> que no haya sido usado antes
        /// </summary>
        /// <returns></returns>
        public Atuendo ObtenerAtuendo()
        {
            bool validoRegla = true;
            if (this.Atuendos.Count.Equals(0) || this.Atuendos.FindAll(a => !a.Usado).Count.Equals(0)) this.GenerarCombinacionesDePrendas();

            foreach (Atuendo atuendo in this.Atuendos.FindAll(a => !a.Usado))
            {
                foreach (Regla regla in this.Reglas)
                {
                    if (regla.Validar(atuendo))
                        validoRegla = true;
                    else
                    {
                        validoRegla = false;
                        break;
                    }
                }

                if (validoRegla)
                {
                    atuendo.Usado = true;
                    return atuendo;
                }
            }
            return null;
        }

        /// <summary>
        /// Setea una coleccion de <see cref="Atuendo"/>s con todas las combinaciones de <see cref="Prenda"/>s posibles agrupadas en "n" elementos.
        /// Formula de combinaciones:
        /// n! / (r!(n-r)!)
        /// </summary>
        /// <param name="n"></param>
        private void CombinarPrendas(int n)
        {
            Atuendo atuendo;
            this.Atuendos = new List<Atuendo>();

            foreach (var row in new Combinaciones.Combinaciones(this.Prendas.Count, n).GetRows())
            {
                atuendo = new Atuendo();
                foreach (var seleccion in Combinaciones.Combinaciones.Permute(row, this.Prendas))
                    atuendo.Prendas.Add(seleccion);
                this.Atuendos.Add(atuendo);
            }
        }

        /// <summary>
        /// Genera <see cref="Atuendo"/>s con un numero fijo de <see cref="Prenda"/>s
        /// </summary>
        /// <param name="agrupacion"></param>
        public void GenerarCombinacionesDePrendas(int agrupacion)
        {
            this.CombinarPrendas(agrupacion);
        }

        /// <summary>
        /// Genera <see cref="Atuendo"/>s con un numero aleatorio de <see cref="Prenda"/>s
        /// </summary>
        public void GenerarCombinacionesDePrendas()
        {
            this.CombinarPrendas((new Random()).Next());
        }
    }
}
