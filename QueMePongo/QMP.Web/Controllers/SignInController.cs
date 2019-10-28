using Ar.UTN.QMP.Lib.Entidades.Contexto;
using Ar.UTN.QMP.Lib.Entidades.Usuarios;
using Ar.UTN.QMP.Web.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Ar.UTN.QMP.Web.Controllers
{
    public class SignInController : Controller
    {
        // GET: SignIn
        public ActionResult SignIn()
        {
            return View();
        }

        // POST: SignIn
        [HttpPost]
        public ActionResult SignIn(UsuarioModel model)
        {
            Usuario usr;

            try
            {
                using (QueMePongoDB db = new QueMePongoDB())
                {
                    usr = db.Usuarios.Where(u => u.Username.Equals(model.UserName)).FirstOrDefault();
                    if (usr == null)  // usuario nuevo
                    {
                        usr = new UsrGratis(10, model.UserName);
                        usr.Password = model.Password;
                        db.Usuarios.Add(usr);
                        db.SaveChanges();
                        
                        Session["UsrID"] = usr.UsuarioId;
                        return RedirectToAction("Home", "Home");
                    }
                    else // usuario existente
                    {
                        if (!model.Password.Equals(usr.Password))
                        {
                            ModelState.AddModelError(string.Empty, "La contraseña ingresada es incorrecta.");
                            return View(model);
                        }
                        else
                        {
                            Session["UsrID"] = usr.UsuarioId;
                            return RedirectToAction("Home", "Home");
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                return View(model); // Esto capas que esta mal
            }

        }
    }
}
