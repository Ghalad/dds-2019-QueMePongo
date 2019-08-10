using Ar.UTN.QMP.Lib.Entidades.Atuendos;
using Ar.UTN.QMP.Lib.Entidades.Clima;
using Ar.UTN.QMP.Lib.Entidades.Eventos;
using Ar.UTN.QMP.Lib.Entidades.Reglas;
using Ar.UTN.QMP.Lib.Entidades.Reglas.Condiciones;
using System;
using System.Collections.Generic;

namespace Ar.UTN.QMP.Lib.Entidades.Core
{
    public class AtuendosGestor
    {
        private List<Atuendo> Atuendos { get; set; }
        private List<Prenda> Prendas { get; set; }
        private List<Regla> Reglas { get; set; }
        private Evento Evento { get; set; }

        #region CONSTRUCTOR
        public AtuendosGestor(List<Prenda> prendas, List<Regla> reglas, Evento evento)
        {
            if (prendas != null)
                this.Prendas = prendas;
            else
                throw new Exception("Es necesario informar una lista de prendas");

            if (reglas != null)
                this.Reglas = reglas;
            else
                throw new Exception("Es necesario informar una lista de reglas");

            if (evento != null)
                this.Evento = evento;
            else
                throw new Exception("Es necesario informar un evento");

            this.Atuendos = new List<Atuendo>();
        }
        #endregion CONSTRUCTOR


        #region OPERACIONES
        /// <summary>
        /// Devuelve los atuendos generados
        /// </summary>
        /// <returns></returns>
        public List<Atuendo> ObtenerAtuendos()
        {
            if (this.Atuendos == null)
                throw new Exception("Atuendos no procesados");
            return this.Atuendos;
        }

        /// <summary>
        /// Setea una coleccion de Atuendos con todas las combinaciones de prendas posibles.
        /// </summary>
        public void GenerarAtuendos()
        {
            Atuendo atuendo;
            int max = this.Prendas.Count;

            // Se toma como minimo combinaciones de 3 prendas ya que son las 3 partes del cuerpo que tienen que estar cubiertas siempre
            // y estaria descartados todos los atuendos de 1 y 2 prendas
            for (int i = 3; i < max; i++)
            {
                foreach (var row in new Combinaciones.Combinaciones(this.Prendas.Count, i).GetRows())
                {
                    atuendo = new Atuendo();
                    foreach (var seleccion in Combinaciones.Combinaciones.Permute(row, this.Prendas))
                        atuendo.AgregarPrenda(seleccion);
                    atuendo.Id = "1"; // TODO generacion de IDs
                    this.Atuendos.Add(atuendo);
                }
            }
        }

        /// <summary>
        /// Aplica todas las reglas a la lista de atuendos, quitando los que no son validos.
        /// </summary>
        public void FiltrarAtuendosPorReglas()
        {
            List<Atuendo> removidos = new List<Atuendo>();

            foreach (Atuendo atuendo in this.Atuendos)
            {
                foreach (Regla regla in this.Reglas)
                {
                    if (!regla.Validar(atuendo))
                    {
                        removidos.Add(atuendo); // Atuendo invalido, lo saco de la lista de atuendos
                        break;
                    }
                }
            }

            this.Atuendos.RemoveAll(a => removidos.Contains(a));
        }

        /// <summary>
        /// Filtra la lista de atuendos segun el tipo de evento
        /// </summary>
        public void FiltrarAtuendosPorEvento()
        {
            List<Atuendo> removidos = new List<Atuendo>();

            Regla regla = new Regla();
            List<Caracteristica> listaCar = new List<Caracteristica>();
            listaCar.Add(this.Evento.TipoEvento);
            regla.AgregarCondicion(new CondicionAfirmativa(listaCar));

            foreach (Atuendo atuendo in this.Atuendos)
                if (!regla.Validar(atuendo))
                    removidos.Add(atuendo);

            this.Atuendos.RemoveAll(a => removidos.Contains(a));
        }

        /// <summary>
        /// Filtra la lista de atuendos segun el clima del lugar donde se desarrollara el evento
        /// </summary>
        public void FiltrarAtuendosPorClima()
        {
            List<Atuendo> removidos = new List<Atuendo>();

            WeatherService srvClima = new WeatherService("AR", this.Evento.CiudadEvento);

            Regla regla = new Regla();
            List<Caracteristica> listaCar = new List<Caracteristica>();
            listaCar.Add(new Caracteristica("CLIMA", Tipos.GetInstance().TraducirTemperatura(srvClima.ObtenerTemperatura())));
            regla.AgregarCondicion(new CondicionAfirmativa(listaCar));

            foreach(Atuendo atuendo in this.Atuendos)
                if (!regla.Validar(atuendo))
                    removidos.Add(atuendo);

            this.Atuendos.RemoveAll(a => removidos.Contains(a));
        }
        #endregion OPERACIONES





        [Obsolete("Esto no va")]
        public void MostrarAtuendos()
        {
            int i = 1;
            foreach (Atuendo a in Atuendos)
            {
                Console.WriteLine(string.Format("Atuendo {0} \n", i));
                foreach (Prenda p in a.Prendas)
                {
                    p.MostrarPorPantalla();
                }
                Console.WriteLine("\n");
                i++;
            }
        }
    }
}
