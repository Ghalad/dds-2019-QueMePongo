using System;
using System.Collections.Generic;

namespace Ar.UTN.QMP.Lib.Entidades.Core
{
    public class ColaPedidos
    {
        private static ColaPedidos Instance { get; set; }
        private Queue<Pedido> ColaDePedidos { get; set; }


        #region CONSTRUCTOR
        private ColaPedidos()
        {
            this.ColaDePedidos = new Queue<Pedido>();
        }

        public static ColaPedidos GetInstance()
        {
            if (Instance == null) Instance = new ColaPedidos();
            return Instance;
        }
        #endregion CONSTRUCTOR

        /// <summary>
        /// Se encarga de recibir pedidos y encolarlos
        /// </summary>
        /// <param name="pedido"></param>
        public void AgregarPedido(Pedido pedido)
        {
            if (pedido != null)
                this.ColaDePedidos.Enqueue(pedido);
            else
                throw new Exception("No se puede agregar un pedido nulo");
        }


        /// <summary>
        /// Se encarga de desencolar pedidos o informar cola vacia
        /// </summary>
        public void DesencolarPedido()
        {
            if (this.ColaDePedidos.Count == 0)
                throw new Exception("No hay pedidos para procesar");
            else
                AtenderPedido(this.ColaDePedidos.Dequeue());
        }


        /// <summary>
        /// Resuelve un pedido en concreto
        /// </summary>
        /// <param name="pedido"></param>
        private void AtenderPedido(Pedido pedido)
        {
            pedido.Resolver();
        }


        /// <summary>
        /// Para usar en los tests.. Encolar pedidos, iniciar scheduler y fijarte cuantos pedidos quedan
        /// </summary>
        /// <returns></returns>
        public int CantidadPedidos()
        {
            return this.ColaDePedidos.Count;
        }
    }
}
