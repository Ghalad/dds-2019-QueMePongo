using Ar.UTN.QMP.Lib.Entidades.Contexto;
using System;

namespace Ar.UTN.QMP.Lib.Entidades.Core
{
    public class Scheduler
    {
        private static Scheduler Instance { get; set; }
        private NodoPedido Nodo { get; set; }

        private Scheduler()
        {
            inicializarPedidos();
        }

        public static Scheduler GetInstance()
        {
            if (Instance == null) Instance = new Scheduler();
            return Instance;
        }



        /// <summary>
        /// Se encarga de recibir pedidos y encolarlos
        /// </summary>
        /// <param name="pedido"></param>
        public void AgregarPedido(Pedido pedido)
        {
            if (pedido != null)
            {
                pedido.GrupoPertenencia = "S";
                if (this.Nodo != null)
                    this.Nodo = this.Nodo.Agregar(pedido);
                else
                    this.Nodo = new NodoPedido(pedido, null);
            }
            else
                throw new Exception("No se puede agregar un pedido nulo");
        }

        /// <summary>
        /// Se encarga de desencolar pedidos o informar cola vacia
        /// </summary>
        public void DesencolarPedido()
        {
            if (this.Nodo != null)
            {
                if (TieneTrabajo())
                {
                    AtenderPedido(this.Nodo.Pedido);
                    if(this.Nodo.Pedido.Estado == Pedido.Estados.RESUELTO)
                    {
                        (new LogDB()).Debug(this.GetType().Name, string.Format("Pedido {0} resuelto", this.Nodo.Pedido.PedidoId));
                        this.Nodo = this.Nodo.QuitarPrimero();
                    }
                }
                else
                    (new LogDB()).Debug(this.GetType().Name, "No tengo trabajo");
            }
            else
                   (new LogDB()).Debug(this.GetType().Name, "Nodo vacio");
        }


        /// <summary>
        /// Resuelve un pedido en concreto
        /// </summary>
        /// <param name="pedido"></param>
        private void AtenderPedido(Pedido pedido)
        {
            pedido.Resolver();
            if (pedido.SeRepite())
            {
                Pedido nuevo = pedido.ObtenerSiguiente();
                nuevo.PedidoId = (new PedidoDB()).Agendar(nuevo.Usuario.UsuarioId, nuevo.Evento.TipoEvento.Valor, nuevo.Evento.FechaEvento, nuevo.Evento.CiudadEvento, nuevo.Evento.Descripcion, nuevo.Evento.Repeticion);
            }
        }

        /// <summary>
        /// Para usar en los tests.. Encolar pedidos, iniciar scheduler y fijarte cuantos pedidos quedan
        /// </summary>
        /// <returns></returns>
        public int CantidadPedidos()
        {
            if (this.Nodo == null) return 0;
            return this.Nodo.CantidadPedidos();
        }


        /// <summary>
        /// Devuelve TRUE si exiten 1 pedido para resolver en el dia.
        /// </summary>
        /// <returns></returns>
        public bool TieneTrabajo()
        {
            if (this.Nodo == null)
                return false;
            else if (DateTime.Compare(DateTime.Now.Date, this.Nodo.Pedido.Fecha().Date) >= 0 || Math.Abs(DateTime.Now.Subtract(this.Nodo.Pedido.Fecha()).Days) < 4)
                return true;
            return false;
        }

        public void inicializarPedidos()
        {
            var pendientes = (new PedidoDB()).Cargar("S");
            foreach (var pedido in pendientes)
                this.AgregarPedido(pedido);
        }
    }
}
