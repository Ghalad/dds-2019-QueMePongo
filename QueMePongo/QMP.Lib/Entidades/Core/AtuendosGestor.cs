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
            this.FiltrarAtuendosPrendasUsadas();
        }

        private void FiltrarAtuendosPrendasUsadas()
        {
            List<Atuendo> removidos = new List<Atuendo>();

            foreach (Atuendo a in Atuendos)
            {
                if (a.TienePrendasUsadas())
                {
                    removidos.Add(a);
                }
            }

            this.Atuendos.RemoveAll(a => removidos.Contains(a));
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
        
        public void FiltrarAtuendosPorClima2(string RelacionConClima)
        {
            List<Atuendo> removidos = new List<Atuendo>();

            int NivelMinimoDeAbrigo = this.DefinirNivelDeAbrigo(RelacionConClima);
            int NivelMaximoDeAbrigo = NivelMinimoDeAbrigo + 5;

            foreach(Atuendo a in Atuendos)
            {
                if(a.NivelDeAbrigo() < NivelMinimoDeAbrigo || a.NivelDeAbrigo() > NivelMaximoDeAbrigo )
                {
                    removidos.Add(a);
                }
            }

            this.Atuendos.RemoveAll(a => removidos.Contains(a));
        }

        private int DefinirNivelDeAbrigo(string RelacionConClima)
        {
            int IndiceDeCalefaccion = this.DefinirIndiceCalefaccion(RelacionConClima);
            int InicioTemperaturaFria = 4 + IndiceDeCalefaccion;
            int InicioTemperaturaMedia = 10 + IndiceDeCalefaccion;
            int InicioTemperaturaCalurosa = 18 + IndiceDeCalefaccion;
            int InicioTemperaturaMuyCalurosa = 23 + IndiceDeCalefaccion;
            //^ se pueden agregar mas niveles

            WeatherService srvClima = new WeatherService("AR", this.Evento.CiudadEvento);
            decimal temperatura = srvClima.ObtenerTemperatura();

            switch (temperatura)
            {
                case decimal n when n < InicioTemperaturaFria:
                    return 22;
                case decimal n when n < InicioTemperaturaMedia:
                    return 17;
                case decimal n when n < InicioTemperaturaCalurosa:
                    return 12;
                case decimal n when n < InicioTemperaturaMuyCalurosa:
                    return 7;
                default:
                    return 10; // este caso nunca se ejecutaría pero me tira error si no lo pongo
            }
        }

        private int DefinirIndiceCalefaccion(string RelacionConClima)
        {
            try
            {
                if (RelacionConClima.ToUpper() == "MUY FRIOLENTO")
                {
                    return 7;
                } else if (RelacionConClima.ToUpper() == "FRIOLENTO")
                {
                    return 4;
                } else if (RelacionConClima.ToUpper() == "NORMAL")
                {
                    return 0;
                } else if (RelacionConClima.ToUpper() == "CALUROSO")
                {
                    return -4;
                } else if (RelacionConClima.ToUpper() == "MUY CALUROSO")
                {
                    return -7;
                }
                else
                {
                    return 0;
                }

            }
            catch{
                throw new Exception("El usuario no tiene relacion con clima.");

            }
        }
        #endregion OPERACIONES

        public void OrdenarPorCalificacionDeAtuendo()
        {
            List<Atuendo> listaOrdenada = new List<Atuendo>();
            Atuendo atuendoAux;

            for (int i = 0; i < this.Atuendos.Count; i++)
            { //burbujeo
                for ( int j = 0 ; j < this.Atuendos.Count - i ; j++ )
                {
                    if(this.Atuendos[j].ObtenerPuntaje() < this.Atuendos[j + 1].ObtenerPuntaje())
                    {
                        atuendoAux = this.Atuendos[j];
                        this.Atuendos[j] = this.Atuendos[j + 1];
                        this.Atuendos[j + 1] = atuendoAux;
                    }
                }
            }return;

        }




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
