using Ar.UTN.QMP.Lib.Entidades.Atuendos;
using Ar.UTN.QMP.Lib.Entidades.Clima;
using Ar.UTN.QMP.Lib.Entidades.Eventos;
using Ar.UTN.QMP.Lib.Entidades.Reglas;
using Ar.UTN.QMP.Lib.Entidades.Reglas.Condiciones;
using System;
using System.Collections.Generic;

namespace Ar.UTN.QMP.Lib.Entidades.Core
{
    public class GestorAtuendos
    {
        private List<Atuendo> Atuendos { get; set; }
        private List<Prenda> Prendas { get; set; }
        private List<Regla> Reglas { get; set; }
        private Evento Evento { get; set; }

        #region CONSTRUCTOR
        public GestorAtuendos(List<Prenda> prendas, List<Regla> reglas, Evento evento)
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


        #region OPERACIONES
        /// <summary>
        /// Setea una coleccion de Atuendos con todas las combinaciones de prendas posibles.
        /// </summary>
        public void GenerarAtuendos()
        {
            Atuendo atuendo;
            int max = this.Prendas.Count;

            // Se toma como minimo combinaciones de 3 prendas ya que son las 3 partes del cuerpo que tienen que estar cubiertas siempre
            // y estaria descartados todos los atuendos de 1 y 2 prendas
            for (int i = 2; i < max; i++)
            {
                foreach (var row in new Combinaciones.Combinaciones(this.Prendas.Count, i).GetRows())
                {
                    atuendo = new Atuendo();
                    foreach (Prenda seleccion in Combinaciones.Combinaciones.Permute(row, this.Prendas))
                        atuendo.AgregarPrenda(seleccion);
                    this.Atuendos.Add(atuendo);
                }
            }
        }

        /// <summary>
        /// Quita de la seleccion los atuendos con prendas ya usadas
        /// </summary>
        public void FiltrarAtuendosPrendasUsadas()
        {
            List<Atuendo> removidos = new List<Atuendo>();

            foreach (Atuendo unAtuendo in this.Atuendos)
            {
                if (unAtuendo.TienePrendasUsadas())
                {
                    removidos.Add(unAtuendo);
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
        /// Quita los atuedno que no cumplen con la sensibilidad y la temperadura
        /// </summary>
        /// <param name="sensibilidad"></param>
        public void FiltrarAtuendosPorSensibilidadYClima(int sensibilidad)
        {
            List<Atuendo> removidos = new List<Atuendo>();

            foreach(Atuendo unAtuendo in this.Atuendos)
            {
                if (!this.CumpleNivelDeAbrigo(sensibilidad, unAtuendo))
                    removidos.Add(unAtuendo);
            }

            this.Atuendos.RemoveAll(a => removidos.Contains(a));
        }

        /// <summary>
        /// Ordenas los atuendos segun su calificacion
        /// </summary>
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
            }
            return;

        }
        #endregion OPERACIONES



        #region FUNCIONES_AUXILIARES

        /// <summary>
        /// Valida que el atuendo cumpla con el nivel de abrigo tolerado por el usuario
        /// </summary>
        /// <param name="sensibilidadUsuario"></param>
        /// <param name="atuendo"></param>
        /// <returns></returns>
        public bool CumpleNivelDeAbrigo(int sensibilidadUsuario, Atuendo atuendo)
        {
            int abrigoSuperior = atuendo.NivelDeAbrigoPorCategoria("SUPERIOR");
            int abrigoInferior = atuendo.NivelDeAbrigoPorCategoria("INFERIOR");
            int abrigoCalzado  = atuendo.NivelDeAbrigoPorCategoria("CALZADO");
            int abrigoExtra    = atuendo.NivelDeAbrigoPorCategoria("ACCESORIO");

            int minimoSuperior = 0, maximoSuperior = 0, minimoInferior = 0, maximoInferior = 0, minimoCalzado = 0, maximoCalzado = 0, minimoExtra = 0, maximoExtra = 0;

            /// Relaciona el clima con la sensibilidad del usuario (info abajo)
            /// por ejemplo: si el clima es de temperatura media pero el usuario es friolento, el usuario sentirá un nivel más frío
            /// osea sentirá que hace frío. Si el clima es de temperatura fria y, de nuevo, el usuario es friolento, la
            /// sentirá como muy fría.
            /// Si hace calor y el usuario es muy friolento baja dos niveles: sentirá frío.
            /// Si hace calor y el usuario es caluroso sube un nivel: sentirá mucho calor.
            /// El nivel máximo y mínimo de sensibilidad es mucho calor y mucho frío relativamente. El usuario no puede 
            /// ser más o menos sensible que eso
            int n = sensibilidadUsuario + this.SensibilidadClima();

            if (n <= -2) //Hace "MUCHO FRIO"
            {
                minimoSuperior = 12;
                maximoSuperior = 19;
                minimoInferior = 4; //sólo pantalón largo.. puede actualizarse cuando agreguemos prendas
                maximoInferior = 4;
                minimoCalzado = 3; //si o si con medias
                maximoCalzado = 3;
                minimoExtra = 1; //si o si con un accesorio para el frío
                maximoExtra = 2;
            }
            else if (n == -1) //Hace "FRIO"
            {
                minimoSuperior = 7;
                maximoSuperior = 15;
                minimoInferior = 4; //sólo pantalón largo.. puede actualizarse cuando agreguemos prendas
                maximoInferior = 4;
                minimoCalzado = 2; //con medias o no
                maximoCalzado = 3;
                minimoExtra = 0;
                maximoExtra = 2;
            }
            else if (n == 0) //Hay temperatura "AMBIENTE"
            {
                minimoSuperior = 2;
                maximoSuperior = 4;
                minimoInferior = 2; //pantalon corto y pantalon largo
                maximoInferior = 4;
                minimoCalzado = 1; //zapatillas con o sin medias
                maximoCalzado = 3;
                minimoExtra = 0;
                maximoExtra = 2;
            }
            else if (n == 1) //Hace "CALOR"
            {
                minimoSuperior = 1;
                maximoSuperior = 3;
                minimoInferior = 1; //sólo pantalón largo
                maximoInferior = 3;
                minimoCalzado = 0; //sin medias
                maximoCalzado = 2;
                minimoExtra = 0; //sin accesorio
                maximoExtra = 0;
            }
            else if (n == 2) //Hace "MUCHO CALOR"
            {
                minimoSuperior = 1;
                maximoSuperior = 2;
                minimoInferior = 1; //sólo pantalón largo
                maximoInferior = 2;
                minimoCalzado = 0; //si o si con medias
                maximoCalzado = 2;
                minimoExtra = 0; //si o si con un accesorio para el frío
                maximoExtra = 0;
            }
            else 
            {
                // Error ????
            }

            return (this.EstaEntre(minimoSuperior, abrigoSuperior, maximoSuperior) &&
                    this.EstaEntre(minimoInferior, abrigoInferior, maximoInferior) &&
                    this.EstaEntre(minimoCalzado, abrigoCalzado, maximoCalzado) &&
                    this.EstaEntre(minimoExtra, abrigoExtra, maximoExtra));

        }

        /// <summary>
        /// Se define cuál es la sensibilidad relativa del usuario con la temperatura
        /// </summary>
        /// <param name="relacionConClima"></param>
        /// <param name="temperatura"></param>
        /// <returns></returns>
        private int SensibilidadClima()
        {
            WeatherService srvClima = new WeatherService("AR", this.Evento.CiudadEvento);
            decimal n = srvClima.ObtenerTemperatura();

            if (n < 4) //Temperatura MUY FRIA
            {
                return -2;
            }
            else if (n < 10) //Temperatura FRIA
            {
                return -1;
            }
            else if (n < 15) //Temperatura AMBIENTE
            {
                return 0;
            }
            else if (n < 20) //Temperatura CALOR
            {
                return 1;
            }
            else //Temperatura MUCHO CALOR
            {
                return 2;
            }
        }

        private bool EstaEntre(int minimo, int valor, int maximo)
        {
            return (minimo <= valor && valor <= maximo);
        }
        #endregion FUNCIONES_AUXILIARES
    }
}
