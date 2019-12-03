using Ar.UTN.QMP.Lib.Entidades.Atuendos;
using Ar.UTN.QMP.Lib.Entidades.Contexto;
using Ar.UTN.QMP.Lib.Entidades.Core;
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
                LoadPedidoModel(model);
                return View(model);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                LoadPedidoModel(model);
                return View(model);
            }
        }

        [HttpPost]
        public ActionResult Crear(PedidosModel model)
        {
            PedidoDB p = new PedidoDB();
            int pedidoID;

            try
            {
                pedidoID = p.Crear(Int32.Parse(Session["UsrID"].ToString()), model.SelectedEvento, model.Ciudad, model.Descripcion);
                LoadPedidoModel(model);
                ModelState.AddModelError(string.Empty, "Pedido creado con exito.");
                return View(model);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                LoadPedidoModel(model);
                return View(model);
            }
        }




        public ActionResult Agendar()
        {
            PedidosModel model = new PedidosModel();

            try
            {
                LoadPedidoModel(model);
                return View(model);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                LoadPedidoModel(model);
                return View(model);
            }
        }

        [HttpPost]
        public ActionResult Agendar(PedidosModel model)
        {
            PedidoDB p = new PedidoDB();
            int pedidoID;

            try
            {
                pedidoID = p.Agendar(Int32.Parse(Session["UsrID"].ToString()), model.SelectedEvento, model.FechaEvento, model.Ciudad, model.Descripcion, model.SelectedRepeticion);
                LoadPedidoModel(model);
                ModelState.AddModelError(string.Empty, "Pedido creado con exito.");
                return View(model);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                LoadPedidoModel(model);
                return View(model);
            }
        }


        public ActionResult Listar()
        {
            PedidosModel model = new PedidosModel();
            PedidoDB p = new PedidoDB();

            try
            {
                model.Pedidos = p.Listar(Int32.Parse(Session["UsrID"].ToString()));
                return View(model);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                LoadPedidoModel(model);
                return View(model);
            }
        }



        private void LoadPedidoModel(PedidosModel model)
        {
            model.Eventos = GestorCaracteristicas.GetInstance().Caracteristicas.Where(c => c.Clave.Equals("EVENTO"));
            model.Repeticiones = new List<string>();
            model.Repeticiones.AddRange(new List<string>() { "UNICO", "A DIARIO", "SEMANAL", "MENSUAL", "ANUAL" });
            model.Pedidos = new List<Pedido>();
        }
    }
}