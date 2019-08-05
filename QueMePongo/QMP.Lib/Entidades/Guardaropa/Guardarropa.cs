using Ar.UTN.QMP.Lib.Entidades.Atuendos;
using Ar.UTN.QMP.Lib.Entidades.Eventos;
using Ar.UTN.QMP.Lib.Entidades.Reglas;
using System;
using System.Collections.Generic;

namespace Ar.UTN.QMP.Lib.Entidades.Guardaropa
{
    public class Guardarropa
    {
        public string Id { get; set; }
        private List<Prenda> Prendas { get; set; }
        public List<Atuendo> Atuendos { get; set; }
        public List<Regla> Reglas { get; set; }
        private int MaximoPrendas { get; set; }
        private List<Evento> Eventos { get; set; }

        public Guardarropa(string id, int maximoPrendas)
        {
            this.Id = id;
            this.MaximoPrendas = maximoPrendas;
            this.Atuendos = new List<Atuendo>();
            this.Reglas = new List<Regla>();
            this.Prendas = new List<Prenda>();
        }

        public List<Atuendo> ObtenerAtuendosTemperatura(decimal temperatura)
        {
            if (temperatura < 11)
            {
                this.GenerarCombinacionesDePrendas(6);
            }
            else if (temperatura < 17)
            {
                this.GenerarCombinacionesDePrendas(5);
            }
            else
            {
                CombinarPrendasVersion2(4);
            }

            return this.Atuendos;
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
                    atuendo.AgregarPrenda(seleccion);
                this.Atuendos.Add(atuendo);
            }

        }

        public void CombinarPrendasVersion2(int n)
        {
            Atuendo atuendo;
            this.Atuendos = new List<Atuendo>();

            while(n!=0){

                foreach (var row in new Combinaciones.Combinaciones(this.Prendas.Count, n).GetRows())
                {
                    atuendo = new Atuendo();
                    foreach (var seleccion in Combinaciones.Combinaciones.Permute(row, this.Prendas))
                        atuendo.AgregarPrenda(seleccion);
                    this.Atuendos.Add(atuendo);
                }

                n = n-1;
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
        /// Genera atuendos con un numero aleatorio de Prendas
        /// </summary>
        public void GenerarCombinacionesDePrendas()
        {
            this.CombinarPrendas((new Random()).Next());
        }

        /// <summary>
        /// Agrega Prendas al guardarropas.
        /// Si el guardarropas pertenece a un usuario Gratuito, agregara la prenda siempre y cuando tenga cupo.
        /// </summary>
        /// <param name="prenda"></param>
        public void AgregarPrenda(Prenda prenda)
        {
            if (this.MaximoPrendas == 0)
                this.Prendas.Add(prenda);
            else if (this.Prendas.Count < this.MaximoPrendas)
                this.Prendas.Add(prenda);
            else
                throw new Exception("No se pueden agregar mas prendas");
        }

        public int CantidadPrendas()
        {
            return this.Prendas.Count;
        }
    }
}
