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
                    /*
                    db.Entry(usr).Collection(u => u.Guardarropas).Load();
                    db.Entry(usr).Collection(u => u.Reglas).Load();

                    foreach(Guardarropa guardarropa in usr.Guardarropas)
                    {
                        db.Entry(guardarropa).Collection(g => g.Prendas).Load();
                        foreach (Prenda prenda in guardarropa.Prendas)
                            db.Entry(prenda).Collection(p => p.Caracteristicas).Load();
                    }
                    */
                    
                    Evento evento = new Evento(model.SelectedEvento, model.FechaEvento, model.Ciudad, model.Descripcion, model.SelectedRepeticion);
                    Pedido pedido = new Pedido(usr, evento);

                    QueMePongo qmp = QueMePongo.GetInstance();
                    qmp.AgregarPedido(pedido);

                    db.Pedidos.Add(pedido);
                    db.Entry(usr).State = System.Data.Entity.EntityState.Unchanged;
                    db.SaveChanges();

                    return View(model);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
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