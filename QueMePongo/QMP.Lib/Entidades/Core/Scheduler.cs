using System;

namespace Ar.UTN.QMP.Lib.Entidades.Core
{
    public class Scheduler
    {
        private static Scheduler Instance { get; set; }
        private NodoPedido Nodo { get; set; }

        private Scheduler()
        {

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
            if (this.Nodo == null)
                throw new Exception("No hay pedidos para procesar");
            else
            {
                AtenderPedido(this.Nodo.Pedido);
                this.Nodo = this.Nodo.QuitarPrimero();
            }
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
                this.AgregarPedido(pedido.ObtenerSiguiente());
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
    }
}
