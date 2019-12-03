using Ar.UTN.QMP.Lib.Entidades.Contexto;
using Ar.UTN.QMP.Web.Models;
using System;
using System.Web.Mvc;

namespace Ar.UTN.QMP.Web.Controllers
{
    public class GuardarropasController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Crear(GuardarropaModel model)
        {
            GuardarropaDB g = new GuardarropaDB();
            try
            {
                g.Crear(Int32.Parse(Session["UsrID"].ToString()), model.Nombre);
                ModelState.AddModelError(string.Empty, "Guardarropas creado con exito.");
                return View(model);
            }
            catch(Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(model);
            }
        }

        public ActionResult Listar()
        {
            GuardarropaDB g = new GuardarropaDB();
            try
            {
                return View(g.ObtenerGuardarropas(Int32.Parse(Session["UsrID"].ToString())));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View();
            }
        }
    }
}