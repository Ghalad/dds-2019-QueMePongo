using Ar.UTN.QMP.Lib.Entidades.Core;
using Ar.UTN.QMP.Lib.Entidades.Eventos;
using Ar.UTN.QMP.Lib.Entidades.Usuarios;
using System;
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
                db.Entry(usr).Collection(u => u.Guardarropas).Load();
                if (usr.Guardarropas.Count == 0) throw new Exception("No se puede crear un pedido si el usuario no posee guardarropas.");

                foreach(var gu in usr.Guardarropas)
                {
                    db.Entry(gu).Collection(g => g.Prendas).Load();
                    if (gu.Prendas.Count == 0) throw new Exception("No se puede crear un pedido si el guardarropas no posee prendas.");
                }

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
                var listaPedidos = db.Pedidos.Where(p => p.Usuario.UsuarioId.Equals(userID)).OrderBy(p => p.GrupoPertenencia).ThenBy(p => p.Evento.FechaEvento);
                foreach(Pedido pedido in listaPedidos)
                    db.Entry(pedido).Reference(p => p.Evento).Load();

                return listaPedidos.ToList();
            }
        }


        public List<Pedido> Cargar(string grupo)
        {
            using (QueMePongoDB db = new QueMePongoDB())
            {
                var listaPedidos = db.Pedidos.Where(p => p.GrupoPertenencia == grupo && p.Estado == Pedido.Estados.EN_CURSO);

                foreach (Pedido pedido in listaPedidos)
                {
                    db.Entry(pedido).Reference(p => p.Evento).Load();
                    db.Entry(pedido.Evento).Reference(e => e.TipoEvento).Load();
                    db.Entry(pedido).Reference(p => p.Usuario).Load();
                }

                return listaPedidos.OrderBy(p => p.Evento.FechaEvento).ToList();
            }
        }


        public void Actualizar(Pedido pedido)
        {
            using (QueMePongoDB db = new QueMePongoDB())
            {
                db.Pedidos.Attach(pedido);
                db.Entry(pedido).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }


        public Pedido Obtener(string pedidoID)
        {
            using (QueMePongoDB db = new QueMePongoDB())
            {
                var pedido = db.Pedidos.Find(pedidoID);
                db.Entry(pedido).Collection(p => p.Atuendos).Load();
                return pedido;
            }
        }
    }
}
