﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ar.UTN.QMP.Lib.Entidades.Core
{
    public class NodoPedido
    {
        public Pedido Pedido { get; set; }
        private NodoPedido NextNodo { get; set; }

        public NodoPedido(Pedido pedido, NodoPedido nextPedido)
        {
            this.Pedido = pedido;
            this.NextNodo = nextPedido;
        }

        public NodoPedido Agregar(Pedido pedidoNuevo)
        {
            /// 2019.10.21 < 2020.12.30 por lo que se encola adelante y se devuelve como PrimerNodo
            if (pedidoNuevo.Fecha() <= Pedido.Fecha())
                return new NodoPedido(pedidoNuevo, this);
            else
            {
                if (NextNodo != null)
                    NextNodo = NextNodo.Agregar(pedidoNuevo);
                else
                    NextNodo = new NodoPedido(pedidoNuevo, null);
                return this;
            }
        }
        public NodoPedido QuitarPrimero()
        {
            return NextNodo;
        }
        public int CantidadPedidos()
        {
            if (NextNodo == null)
                return 1;
            else
                return 1 + NextNodo.CantidadPedidos();
        }

        public int DentroDeCuanto()
        {
            // 2019.08.30 - 2019.08.20 = 10
            // 2019.08.20 - 2019.08.30 = -10
            //La fecha actual siempre tendría que ser menor que la del evento

            return Pedido.Fecha().Day - DateTime.Now.Day ;
        }
    }
}
