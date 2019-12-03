using Ar.UTN.QMP.Lib.Entidades.Contexto;
using Ar.UTN.QMP.Lib.Entidades.Usuarios;
using Ar.UTN.QMP.Web.Models;
using System;
using System.Web.Mvc;

namespace Ar.UTN.QMP.Web.Controllers
{
    public class SignInController : Controller
    {
        public ActionResult SignIn()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult SignIn(UsuarioModel model)
        {
            UsuarioDB usrDB = new UsuarioDB();

            try
            {
                Session["UsrID"] = usrDB.LogIn(model.UserName, model.Password);
                return RedirectToAction("Home", "Home");
            }
            catch(Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(model);
            }
        }
    }
}
