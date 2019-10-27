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
    }
}