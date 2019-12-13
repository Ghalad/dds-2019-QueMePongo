using Ar.UTN.QMP.Lib.Entidades.Atuendos;
using Ar.UTN.QMP.Lib.Entidades.Calificaciones;
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
            Pedido pedidoDB;
            Atuendo atuendoDB;

            using (QueMePongoDB db = new QueMePongoDB())
            {
                pedidoDB = db.Pedidos.Find(pedido.PedidoId);

                foreach (Atuendo atuendo in pedido.Atuendos)
                {
                    atuendoDB = new Atuendo();
                    foreach (Prenda prenda in atuendo.Prendas)
                    {
                        atuendoDB.Prendas.Add(db.Prendas.Find(prenda.PrendaId));
                    }
                    pedidoDB.Atuendos.Add(atuendoDB);
                }
                pedidoDB.GrupoPertenencia = pedido.GrupoPertenencia;
                pedidoDB.Estado = Pedido.Estados.RESUELTO;
                pedidoDB.Evento = db.Eventos.Find(pedido.Evento.EventoId);
                pedidoDB.Usuario = db.Usuarios.Find(pedido.Usuario.UsuarioId);
                db.SaveChanges();
            }
        }


        public Pedido ObtenerPedido(int pedidoID)
        {
            using (QueMePongoDB db = new QueMePongoDB())
            {
                var pedido = db.Pedidos.Find(pedidoID);
                db.Entry(pedido).Collection(p => p.Atuendos).Load();
                foreach (Atuendo atuendo in pedido.Atuendos)
                {
                    db.Entry(atuendo).Collection(a => a.Prendas).Load();
                    foreach (Prenda prenda in atuendo.Prendas)
                    {
                        db.Entry(prenda).Collection(p => p.Caracteristicas).Load();
                    }
                }
                return pedido;
            }
        }

        public Atuendo ObtenerAtuendo(int atuendoID)
        {
            Atuendo atuendo;
            using (QueMePongoDB db = new QueMePongoDB())
            {
                atuendo =  db.Atuendos.Find(atuendoID);
                db.Entry(atuendo).Collection(a => a.Prendas).Load();

                foreach (Prenda prenda in atuendo.Prendas)
                {
                    db.Entry(prenda).Collection(p => p.Caracteristicas).Load();
                }
            }

            return atuendo;
        }

        public void PuntuarAtuendo(int userID, int atuendoID, int puntaje)
        {
            Atuendo atuendoDB;
            Usuario user;
            using (QueMePongoDB db = new QueMePongoDB())
            {
                atuendoDB = db.Atuendos.Find(atuendoID);
                db.Entry(atuendoDB).Collection(a => a.Prendas).Load();

                foreach (Prenda prenda in atuendoDB.Prendas)
                {
                    db.Entry(prenda).Collection(p => p.Caracteristicas).Load();
                }
                user = db.Usuarios.Find(userID);
                atuendoDB.Aceptar(user, puntaje);
                db.Entry(atuendoDB).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}
