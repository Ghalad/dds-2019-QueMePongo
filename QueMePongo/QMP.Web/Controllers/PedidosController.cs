using Ar.UTN.QMP.Lib.Entidades.Atuendos;
using Ar.UTN.QMP.Lib.Entidades.Contexto;
using Ar.UTN.QMP.Lib.Entidades.Core;
using Ar.UTN.QMP.Lib.Entidades.Eventos;
using Ar.UTN.QMP.Lib.Entidades.Usuarios;
using Ar.UTN.QMP.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Ar.UTN.QMP.Web.Controllers
{
    public class PedidosController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Crear()
        {
            PedidosModel model = new PedidosModel();

            try
            {
                LoadPedido(model);
                return View(model);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                LoadPedido(model);
                return View(model);
            }
        }

        [HttpPost]
        public ActionResult Crear(PedidosModel model)
        {
            try
            {
                using (QueMePongoDB db = new QueMePongoDB())
                {
                    Usuario usr = db.Usuarios.Find(Session["UsrID"]);
                    
                    Evento evento = new Evento(model.SelectedEvento, model.FechaEvento, model.Ciudad, model.Descripcion, model.SelectedRepeticion);
                    Pedido pedido = new Pedido(usr, evento);

                    ColaPedidos qmp = ColaPedidos.GetInstance();
                    qmp.AgregarPedido(pedido);

                    db.Pedidos.Attach(pedido);
                    db.Entry(evento.TipoEvento).State = System.Data.Entity.EntityState.Unchanged;
                    db.SaveChanges();

                    LoadPedido(model);
                    return View(model);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                LoadPedido(model);
                return View(model);
            }
        }



        private void LoadPedido(PedidosModel model)
        {
            model.Eventos = GestorCaracteristicas.GetInstance().Caracteristicas.Where(c => c.Clave.Equals("EVENTO"));
            model.Repeticiones = new List<string>();
            model.Repeticiones.AddRange(new List<string>() { "UNICO", "A DIARIO", "SEMANAL", "MENSUAL", "ANUAL" });
        }
    }
}