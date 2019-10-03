using Ar.UTN.QMP.Lib.Entidades.Atuendos;
using Ar.UTN.QMP.Lib.Entidades.Eventos;
using Ar.UTN.QMP.Lib.Entidades.Reglas;
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
        [Key, ForeignKey("Usuario")]
        public int Id { get; set; }
        private ICollection<Prenda> Prendas { get; set; }
        private ICollection<Regla> Reglas { get; set; }

        public DateTime Fecha()
        {
            return Evento.FechaEvento;
        }

        private Evento Evento { get; set; }
        public Usuario Usuario { get; set; }
        private ICollection<Atuendo> Atuendos { get; set; }

        public Pedido(Usuario usr, Evento evento)
        {
            if (usr != null)
                this.Usuario = usr;
            else
                throw new Exception("Es necesario informar un usuario");

            Prendas = usr.ObtenerPrendas();
            Reglas = usr.Reglas;

            if (Prendas.Count == 0)
                throw new Exception("El usuario no tiene prendas para generar atuendos");

            if (Reglas.Count == 0)
                throw new Exception("Es necesario informar una lista de reglas");

            if (evento != null)
                this.Evento = evento;
            else
                throw new Exception("Es necesario informar un evento");

            this.Atuendos = new List<Atuendo>();
        }

        /// <summary>
        /// Resuelve el pedido, generando un atuendo y haciendolo disponible para que el usuario lo obtenga previa notificacion
        /// </summary>
        public void Resolver()
        {
            AtuendosGestor gestor = new AtuendosGestor(this.Prendas.ToList(), this.Reglas.ToList(), this.Evento);
            gestor.GenerarAtuendos();
            gestor.FiltrarAtuendosPorReglas();
            gestor.FiltrarAtuendosPorEvento();
            //gestor.FiltrarAtuendosPorClima();
            gestor.FiltrarAtuendosPorSensibilidadYClima(this.Usuario.Sensibilidad);
            gestor.OrdenarPorCalificacionDeAtuendo();

            this.Atuendos = gestor.ObtenerAtuendos();
            this.NotificarUsuario();
        }

        public Pedido ObtenerSiguiente()
        {
            return new Pedido(this.Usuario, Evento.ObtenerSiguiente());
        }

        public bool SeRepite()
        {
            return (Evento.SeRepite());
        }

        /// <summary>
        /// Obtiene un atuendo que no haya sido marcado antes
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
        public void AceptarAtuendo(Usuario usr, string id, int puntaje)
        {
            usr.AgregarAtuendoAceptado(this.Atuendos.ToList().Find(a => a.AtuendoId.Equals(id)));
            this.Atuendos.ToList().Find(a => a.AtuendoId.Equals(id)).Aceptar(puntaje);
            this.Atuendos.ToList().ForEach(a => { if (!a.AtuendoId.Equals(id)) a.Rechazar(); });
        }


        /// <summary>
        /// Permite deshacer la operacion anterior
        /// </summary>
        public void DeshacerUltimaOperacion()
        {
            foreach(Atuendo atuendo in this.Atuendos)
            {
                atuendo.Deshacer();
            }
        }

        public void NotificarUsuario()
        {
            this.Usuario.NotificarPedidoResuelto(this);
        }


        [Obsolete] //solo la uso para un test
        public void AceptarPrimerAtuendo()
        {
            if(this.Atuendos.Count == 0)
            {
                throw new Exception("El usuario no tiene atuendos para aceptar.");
            }
            this.Atuendos.ToList()[0].Aceptar(10);
        }
    }
}
