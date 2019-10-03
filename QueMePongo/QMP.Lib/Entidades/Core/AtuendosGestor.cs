using Ar.UTN.QMP.Lib.Entidades.Atuendos;
using Ar.UTN.QMP.Lib.Entidades.Calificaciones;
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
        public void FiltrarAtuendosPorSensibilidadYClima(int sensibilidad)
        {
            List<Atuendo> removidos = new List<Atuendo>();

            foreach(Atuendo a in Atuendos)
            {
                if (!this.CumpleNivelDeAbrigo(sensibilidad, a))
                    removidos.Add(a);
            }

            this.Atuendos.RemoveAll(a => removidos.Contains(a));
        }
        public void OrdenarPorCalificacionDeAtuendo()
        {
            Atuendo atuendoAux;

            for (int i = 0; i < this.Atuendos.Count - 1; i++)
            { //burbujeo de menor a mayor
                for ( int j = 0 ; j < this.Atuendos.Count - 1; j++ )
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

        #endregion OPERACIONES

        #region FUNCIONES AUXILIARES
        private bool CumpleNivelDeAbrigo(int sensibilidadUsuario, Atuendo a)
        {
            int abrigoSuperior = a.AbrigoCategoria("SUPERIOR");
            int abrigoInferior = a.AbrigoCategoria("INFERIOR");
            int abrigoCalzado = a.AbrigoCategoria("CALZADO");
            int abrigoExtra = a.AbrigoCategoria("ACCESORIO");

            int minimoSuperior = 0, maximoSuperior = 0, minimoInferior = 0, maximoInferior = 0, minimoCalzado = 0, maximoCalzado = 0, minimoExtra = 0, maximoExtra = 0;

            /// Relaciona el clima con la sensibilidad del usuario (info abajo)
            /// por ejemplo: si el clima es de temperatura media pero el usuario es friolento, el usuario la sentirá un nivel más frío
            ///                osea sentirá que hace frío. Si el clima es de temperatura fria y, de nuevo, el usuario es friolento, la
            ///                sentirá como muy fría.
            ///                Si hace calor y el usuario es muy friolento baja dos niveles: sentirá frío.
            ///                Si hace calor y el usuario es caluroso sube un nivel: sentirá mucho calor.
            ///                El nivel máximo y mínimo de sensibilidad es mucho calor y mucho frío relativamente. El usuario no puede 
            ///                ser más o menos sensible que eso
            switch (sensibilidadUsuario + this.SensibilidadClima())
            {
                case int n when n <= -2: //Hace "MUCHO FRIO"
                    minimoSuperior = 12;
                    maximoSuperior = 19;
                    minimoInferior = 4; //sólo pantalón largo.. puede actualizarse cuando agreguemos prendas
                    maximoInferior = 4;
                    minimoCalzado = 3; //si o si con medias
                    maximoCalzado = 3;
                    minimoExtra = 1; //si o si con un accesorio para el frío
                    maximoExtra = 2;
                    break;
                case int n when n == -1: //Hace "FRIO"
                    minimoSuperior = 7;
                    maximoSuperior = 15;
                    minimoInferior = 4; //sólo pantalón largo.. puede actualizarse cuando agreguemos prendas
                    maximoInferior = 4;
                    minimoCalzado = 2; //con medias o no
                    maximoCalzado = 3;
                    minimoExtra = 0;
                    maximoExtra = 2;
                    break;
                case int n when n == 0 : //Hay temperatura "AMBIENTE"
                    minimoSuperior = 4;
                    maximoSuperior = 7;
                    minimoInferior = 3; //pantalon corto y pantalon largo
                    maximoInferior = 4; 
                    minimoCalzado = 2; //zapatillas con o sin medias
                    maximoCalzado = 3;
                    minimoExtra = 0;
                    maximoExtra = 2;
                    break;
                case int n when n == 1 : //Hace "CALOR"
                    minimoSuperior = 3;
                    maximoSuperior = 4;
                    minimoInferior = 3; //sólo pantalón largo
                    maximoInferior = 3;
                    minimoCalzado = 2; //sin medias
                    maximoCalzado = 2;
                    minimoExtra = 0; //sin accesorio
                    maximoExtra = 0;
                    break;
                case int n when n == 2 : //Hace "MUCHO CALOR"
                    minimoSuperior = 2;
                    maximoSuperior = 3;
                    minimoInferior = 4; //sólo pantalón largo
                    maximoInferior = 4;
                    minimoCalzado = 2; //si o si con medias
                    maximoCalzado = 3;
                    minimoExtra = 0; //si o si con un accesorio para el frío
                    maximoExtra = 0;
                    break;
            }

            return (this.EstaEntre(minimoSuperior, abrigoSuperior, maximoSuperior)
                    && this.EstaEntre(minimoInferior, abrigoInferior, maximoInferior)
                    && this.EstaEntre(minimoCalzado, abrigoCalzado, maximoCalzado)
                    && this.EstaEntre(minimoExtra, abrigoExtra, maximoExtra));

        }
        /// <summary>
        ///  Se define cuál es la sensibilidad relativa del usuario con la temperatura
        /// </summary>
        /// <param name="relacionConClima"></param>
        /// <param name="temperatura"></param>
        /// <returns></returns>
        private int SensibilidadClima()
        {
            WeatherService srvClima = new WeatherService("AR", this.Evento.CiudadEvento);

            switch (srvClima.ObtenerTemperatura())
            {
                case decimal n when n < 4: //Temperatura MUY FRIA
                    return -2;
                case decimal n when n < 10: //Temperatura FRIA
                    return -1;
                case decimal n when n < 15: //Temperatura AMBIENTE
                    return 0;
                case decimal n when n < 20: //Temperatura CALOR
                    return 1;
                default: //Temperatura MUCHO CALOR
                    return 2;
            }
        }
        private bool EstaEntre(int minimo, int valor, int maximo)
        {
            return (minimo <= valor && valor <= maximo);
        }
        #endregion

        #region OBSOLETAS
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
        /// <summary>
        /// Filtra la lista de atuendos segun el clima del lugar donde se desarrollara el evento
        /// </summary>
        [Obsolete]
        public void FiltrarAtuendosPorClima2()
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
        #endregion
    }
}
