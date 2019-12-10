using Ar.UTN.QMP.Lib.Entidades.Atuendos;
using Ar.UTN.QMP.Lib.Entidades.Contexto;
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
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PedidoId { get; set; }
        public Estados Estado { get; set; }
        public string GrupoPertenencia { get; set; }
        public Evento Evento { get; set; }
        public Usuario Usuario { get; set; }
        public ICollection<Atuendo> Atuendos { get; set; }

        public enum Estados
        {
            EN_CURSO,
            RESUELTO
        }

        #region CONSTRUCTOR
        private Pedido()
        {
            this.Estado = Estados.EN_CURSO;
            this.Atuendos = new List<Atuendo>();
        }

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
            this.Estado = Estados.EN_CURSO;
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
            this.ActualizarDatosDelUsuario();
            GestorAtuendos gestor = new GestorAtuendos(this.Usuario.ObtenerPrendas(), this.Usuario.Reglas.ToList(), this.Evento);
            gestor.GenerarAtuendos();
            gestor.FiltrarAtuendosPrendasUsadas();
            gestor.FiltrarAtuendosPorReglas();
            gestor.FiltrarAtuendosPorEvento();
            gestor.FiltrarAtuendosPorSensibilidadYClima(this.Usuario.Sensibilidad);
            gestor.OrdenarPorCalificacionDeAtuendo();

            this.Atuendos = gestor.ObtenerAtuendos();
            this.NotificarUsuario();
            this.Estado = Pedido.Estados.RESUELTO;
            this.ActualizarPedido();
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
        /// <param name="atuendoId"></param>
        public void AceptarAtuendo(int atuendoId, int puntaje)
        {
            Atuendo unAtuendo;
            if (this.Atuendos != null && this.Atuendos.Any(a => a.AtuendoId.Equals(atuendoId)))
            {
                unAtuendo = this.Atuendos.Where(a => a.AtuendoId.Equals(atuendoId)).SingleOrDefault();
                unAtuendo.Aceptar(this.Usuario, puntaje);
                this.Usuario.AgregarAtuendoAceptado(unAtuendo);
                this.NotificarCambioDeClima(unAtuendo);
            }
            else
                throw new Exception("Identificador de atuendo invalido o lista vacia.");
        }


        /// <summary>
        /// Permite deshacer la ultima calificacion del usuario
        /// </summary>
        public void DeshacerUltimaOperacion()
        {
            foreach(Atuendo unAtuendo in this.Atuendos)
            {
                unAtuendo.DeshacerUltimaOperacion(Usuario.UsuarioId);
            }
        }

        /// <summary>
        /// Notifica al usuario si hubo un cambio de clima abrupto para el atuendo seleccionado para el evento
        /// </summary>
        /// <param name="unAtuendo"></param>
        private void NotificarCambioDeClima(Atuendo unAtuendo)
        {
            GestorAtuendos gestor = new GestorAtuendos(this.Usuario.ObtenerPrendas(), this.Usuario.Reglas.ToList(), this.Evento);
            if (!gestor.CumpleNivelDeAbrigo(this.Usuario.Sensibilidad, unAtuendo))
            {
                this.Usuario.Notificar("Las condiciones climaticas han cambiado abruptamente");
            }
        }

        /// <summary>
        /// Notifica al usuario que el pedido ya esta resuelto
        /// </summary>
        public void NotificarUsuario()
        {
            this.Usuario.NotificarPedidoResuelto(this.PedidoId);
        }


        /// <summary>
        /// Actualiza los datos del usuario
        /// </summary>
        private void ActualizarDatosDelUsuario()
        {
            this.Usuario = (new UsuarioDB()).Cargar(this.Usuario.UsuarioId);
        }

        public void ActualizarPedido()
        {
            (new PedidoDB()).Actualizar(this);
        }
    }
}
