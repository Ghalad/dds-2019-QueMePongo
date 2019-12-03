using Ar.UTN.QMP.Lib.Entidades.Core;
using Ar.UTN.QMP.Lib.Entidades.Eventos;
using Ar.UTN.QMP.Lib.Entidades.Usuarios;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Ar.UTN.QMP.Lib.Entidades.Contexto
{
    public class PedidoDB
    {

        public int Crear(int userID, string tipoEvento, string ciudad, string descripcion)
        {
            using (QueMePongoDB db = new QueMePongoDB())
            {
                Usuario usr = db.Usuarios.Find(userID);

                Evento evento = new Evento(tipoEvento, DateTime.Now, ciudad, descripcion, "UNICO");
                Pedido pedido = new Pedido(usr, evento);

                ColaPedidos colapedidos = ColaPedidos.GetInstance();
                colapedidos.AgregarPedido(pedido);

                db.Eventos.Add(evento);
                db.Entry(evento.TipoEvento).State = System.Data.Entity.EntityState.Unchanged;
                db.Pedidos.Add(pedido);
                db.SaveChanges();

                return pedido.PedidoId;
            }
        }


        public int Agendar(int userID, string tipoEvento, DateTime fechaEvento, string ciudad, string descripcion, string repeticion)
        {
            using (QueMePongoDB db = new QueMePongoDB())
            {
                Usuario usr = db.Usuarios.Find(userID);

                Evento evento = new Evento(tipoEvento, fechaEvento, ciudad, descripcion, repeticion);
                Pedido pedido = new Pedido(usr, evento);

                Scheduler scheduler = Scheduler.GetInstance();
                scheduler.AgregarPedido(pedido);

                db.Eventos.Add(evento);
                db.Entry(evento.TipoEvento).State = System.Data.Entity.EntityState.Unchanged;
                db.Pedidos.Add(pedido);
                db.SaveChanges();

                return pedido.PedidoId;
            }
        }


        public List<Pedido> Listar(int userID)
        {
            using (QueMePongoDB db = new QueMePongoDB())
            {
                var listaPedidos = db.Pedidos.Where(p => p.Usuario.UsuarioId.Equals(userID)).ToList();

                foreach(Pedido pedido in listaPedidos)
                {
                    db.Entry(pedido).Reference(p => p.Evento).Load();
                }

                return listaPedidos;
            }
        }
    }
}
