using System;
using System.Collections.Generic;
using System.Threading;

namespace Ar.UTN.QMP.Lib.Entidades.Core
{
    public class QueMePongo
    {
        private static QueMePongo Instance { get; set; }

        private static Queue<Pedido> NuevosPedidos { get; set; }
        private Thread PedidosHandler { get; set; }
        private static int TIEMPO_ESPERA; // Unidad: segundos

        #region CONSTRUCTOR
        private QueMePongo()
        {
            NuevosPedidos = new Queue<Pedido>();
            TIEMPO_ESPERA = 2; // Parametro que se podria levantar de la base o por archivo de configuracion.
            PedidosHandler = new Thread(new ThreadStart(AtenderPedido));
            PedidosHandler.Start();
        }

        public static QueMePongo GetInstance()
        {
            if (Instance == null) Instance = new QueMePongo();
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
                NuevosPedidos.Enqueue(pedido);
        }



        #region OPERACIONES_THREADS
        /// <summary>
        /// Desencola un Pedido y lo procesa, entregando finalmente un atuendo al usuario.
        /// Si no quedan Pedidos por procesar, el hilo encargado del procesamiento, se duerme una determinada cantidad de tiempo.
        /// </summary>
        private static void AtenderPedido()
        {
            Pedido pedido;

            while (true)
            {
                try
                {
                    pedido = NuevosPedidos.Dequeue();
                    // Procesar pedido
                    Console.WriteLine(string.Format("Pedido {0} atendido", pedido.Id));
                }
                catch (InvalidOperationException)
                {
                    Console.WriteLine("No hay pedidos para atender, me voy a dormir");
                    Thread.Sleep(TIEMPO_ESPERA * 1000);
                }
            }
        }
        #endregion OPERACIONES_THREADS
    }
}
