using System.Web.Mvc;

namespace WebApiAkqa.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult AkqActionResult()
        {
            ViewBag.Title = "AKQA Web API Page";
            return View();
        }
    }
}
