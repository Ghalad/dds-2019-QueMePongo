using Ar.UTN.QMP.Lib.Entidades.Contexto;
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
            inicializarPedidos();
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
            {
                pedido.GrupoPertenencia = "C";
                this.ColaDePedidos.Enqueue(pedido);
            }
            else
                throw new Exception("No se puede agregar un pedido nulo");
        }


        /// <summary>
        /// Se encarga de desencolar pedidos o informar cola vacia
        /// </summary>
        public void DesencolarPedido()
        {
            int id;
            if (this.ColaDePedidos.Count > 0)
            {
                id = AtenderPedido(this.ColaDePedidos.Dequeue());
            }
        }


        /// <summary>
        /// Resuelve un pedido en concreto
        /// </summary>
        /// <param name="pedido"></param>
        private int AtenderPedido(Pedido pedido)
        {
            pedido.Resolver();
            return pedido.PedidoId;
        }


        /// <summary>
        /// Para usar en los tests.. Encolar pedidos, iniciar scheduler y fijarte cuantos pedidos quedan
        /// </summary>
        /// <returns></returns>
        public int CantidadPedidos()
        {
            return this.ColaDePedidos.Count;
        }


        public void inicializarPedidos()
        {
            foreach(var p in (new PedidoDB()).Cargar("C"))
                this.ColaDePedidos.Enqueue(p);
        }
    }
}
