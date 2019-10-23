using Ar.UTN.QMP.Lib.Entidades.Atuendos;
using Ar.UTN.QMP.Lib.Entidades.Eventos;
using Ar.UTN.QMP.Lib.Entidades.Usuarios;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Ar.UTN.QMP.Lib.Entidades.Core
{
    [Table("Pedidos")]
    public class Pedido
    {
        [Key, ForeignKey("Usuario"), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PedidoId { get; set; }
        public Evento Evento { get; set; }
        public Usuario Usuario { get; set; }
        public ICollection<Atuendo> Atuendos { get; set; }


        #region CONSTRUCTOR
        private Pedido() { }

        public Pedido(Usuario usr, Evento evento)
        {
            if (usr != null)
                this.Usuario = usr;
            else
                throw new Exception("Es necesario informar un usuario");

            if (evento != null)
                this.Evento = evento;
            else
                throw new Exception("Es necesario informar un evento");

            this.Atuendos = new List<Atuendo>();
        }
        #endregion CONSTRUCTOR


        /// <summary>
        /// Devuelve la fecha del evento del pedido
        /// </summary>
        /// <returns></returns>
        public DateTime Fecha()
        {
            return Evento.FechaEvento;
        }

        /// <summary>
        /// Resuelve el pedido, generando un atuendo y haciendolo disponible para que el usuario lo obtenga previa notificacion
        /// </summary>
        public void Resolver()
        {
            GestorAtuendos gestor = new GestorAtuendos(this.Usuario.ObtenerPrendas(), this.Usuario.Reglas.ToList(), this.Evento);
            gestor.GenerarAtuendos();
            gestor.FiltrarAtuendosPrendasUsadas();
            gestor.FiltrarAtuendosPorReglas();
            gestor.FiltrarAtuendosPorEvento();
            //gestor.FiltrarAtuendosPorSensibilidadYClima(this.Usuario.Sensibilidad);
            gestor.OrdenarPorCalificacionDeAtuendo();

            this.Atuendos = gestor.ObtenerAtuendos();
            this.NotificarUsuario();
        }

        /// <summary>
        /// Genera un nuevo pedido para el mismo usuario y el mismo evento pero en la proxima fecha segun la configuracion del evento
        /// </summary>
        /// <returns></returns>
        public Pedido ObtenerSiguiente()
        {
            return new Pedido(this.Usuario, this.Evento.ObtenerSiguiente());
        }

        /// <summary>
        /// Indica si el evento del pedido se repite o no
        /// </summary>
        /// <returns></returns>
        public bool SeRepite()
        {
            return this.Evento.SeRepite();
        }

        /// <summary>
        /// Obtiene los atuendo del pedido una vez que fueron procesados
        /// </summary>
        /// <returns></returns>
        public List<Atuendo> ObtenerAtuendos()
        {
            if (this.Atuendos == null)
                throw new Exception("Atuendos no procesados");
            return this.Atuendos.ToList();
        }


        /// <summary>
        /// Permite aceptar un atuendo y rechazar el resto
        /// </summary>
        /// <param name="id"></param>
        public void AceptarAtuendo(int id, int puntaje)
        {
            if (this.Atuendos != null && this.Atuendos.Any(a => a.AtuendoId.Equals(id)))
            {
                this.Atuendos.Where(a => a.AtuendoId.Equals(id)).SingleOrDefault().Aceptar(this.Usuario, puntaje);
                this.Usuario.AgregarAtuendoAceptado(this.Atuendos.Where(a => a.AtuendoId.Equals(id)).SingleOrDefault());
            }
            else
                throw new Exception("Identificador de atuendo invalido o lista vacia.");
        }


        /// <summary>
        /// Permite deshacer la operacion anterior
        /// </summary>
        public void DeshacerUltimaOperacion()
        {
            // ESTO ESTA MAL
            foreach(Atuendo atuendo in this.Atuendos)
                atuendo.Deshacer();
        }

        public void NotificarUsuario()
        {
            this.Usuario.NotificarPedidoResuelto(this);
        }







        [Obsolete]
        public void MostrarAtuendos()
        {
            Console.WriteLine("About to print Atuendos..");
            int i = 1;
            foreach(Atuendo a in Atuendos)
            {
                Console.WriteLine("Atuendo {0}", i);
                foreach(Prenda p in a.Prendas)
                {
;                   p.MostrarPorPantalla();
                }
                i++;
            }
        }
    }
}
