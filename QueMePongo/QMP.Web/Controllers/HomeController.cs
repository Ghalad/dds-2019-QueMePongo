using Ar.UTN.QMP.Lib.Entidades.Atuendos;
using Ar.UTN.QMP.Lib.Entidades.Contexto;
using Ar.UTN.QMP.Lib.Entidades.Usuarios;
using Ar.UTN.QMP.Web.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace QMP.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Home()
        {
            return View();
        }

        public ActionResult Configurar()
        {
            UsuarioModel model = new UsuarioModel();

            try
            {
                LoadUsuarioParaConfigurar(model);
                return View(model);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                LoadUsuarioParaConfigurar(model);
                return View(model);
            }
        }

        [HttpPost]
        public ActionResult Configurar(UsuarioModel model)
        {
            UsuarioDB usrDB = new UsuarioDB();
            try
            {
                usrDB.Modificar(Int32.Parse(Session["UsrID"].ToString()), Int32.Parse(model.SelectedSensibilidad), model.TarjetaCredito);

                ModelState.AddModelError(string.Empty, "Usuario modificado con exito.");
                LoadUsuarioParaConfigurar(model);
                return View(model);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                LoadUsuarioParaConfigurar(model);
                return View(model);
            }
        }






        private void LoadUsuarioParaConfigurar(UsuarioModel model)
        {
            GestorCaracteristicas GeCa;
            UsuarioDB usrDB = new UsuarioDB();

            Usuario usr = usrDB.ObtenerUsuario(Int32.Parse(Session["UsrID"].ToString()));

            model.UserName = usr.Username;
            model.Password = usr.Password;
            if (usr.GetType() == typeof(UsrPremium))
            {
                model.EsUsuarioPremium = true;
                model.TarjetaCredito = ((UsrPremium)usr).TarjetaCredito;
            }
            else
                model.EsUsuarioPremium = false;

            GeCa = GestorCaracteristicas.GetInstance();
            model.Sensibilidades = GeCa.Sensibilidad.Where(c => c.Nombre.Equals("SENSIBILIDAD"));
            model.SelectedSensibilidad = GeCa.ObtenerSensibilidad(usr.Sensibilidad);
        }
    }
}