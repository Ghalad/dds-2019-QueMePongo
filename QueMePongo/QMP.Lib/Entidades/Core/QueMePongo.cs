using System;
using System.Collections.Generic;
using System.Threading;

namespace Ar.UTN.QMP.Lib.Entidades.Core
{
    public class QueMePongo
    {
        private static QueMePongo Instance { get; set; }

        private static Queue<Pedido> NuevosPedidos { get; set; }
        private Thread ThreadPedidos { get; set; }
        private static int TIEMPO_ESPERA; // Unidad: segundos
        [Obsolete]
        public static bool killProcess = false;

        #region CONSTRUCTOR
        private QueMePongo()
        {
            NuevosPedidos = new Queue<Pedido>();
            TIEMPO_ESPERA = 2; // Parametro que se podria levantar de la base o por archivo de configuracion.
            //ThreadPedidos = new Thread(new ThreadStart(AtenderPedido));
            //ThreadPedidos.Start();
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
            else
                throw new Exception("No se puede agregar un pedido nulo");
        }
        
        /// <summary>
        /// Se encarga de desencolar pedidos o informar cola vacia
        /// </summary>
        public void DesencolarPedido()
        {
            if (NuevosPedidos.Count == 0)
                throw new Exception("No hay pedidos para procesar");
            else
                AtenderPedido(NuevosPedidos.Dequeue());
        }



        /// <summary>
        /// Resuelve un pedido en concreto
        /// </summary>
        /// <param name="pedido"></param>
        private void AtenderPedido(Pedido pedido)
        {
            pedido.Resolver();
        }



        #region OPERACIONES_THREADS
        /// <summary>
        /// Desencola un Pedido y lo procesa, entregando finalmente un atuendo al usuario.
        /// Si no quedan Pedidos por procesar, el hilo encargado del procesamiento, se duerme una determinada cantidad de tiempo.
        /// </summary>
        private static void AtenderPedido()
        {
            Pedido pedido;
            int i = 0;

            Console.WriteLine("Iniciando hilo");
            Console.WriteLine("Pedidos pendientes " + NuevosPedidos.Count);

            while (!killProcess)
            {
                try
                {
                    pedido = NuevosPedidos.Dequeue();
                    pedido.Resolver();

                    Console.WriteLine(string.Format("Pedido {0} atendido", i));
                    i++;

                    if (i > 5) killProcess = true;

                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine("No quedan pedidos por atender " + ex.Message);
                    Thread.Sleep(TIEMPO_ESPERA * 1000);
                }
            }


            Console.WriteLine("Terminando hilo");
        }
        #endregion OPERACIONES_THREADS
    }
}
