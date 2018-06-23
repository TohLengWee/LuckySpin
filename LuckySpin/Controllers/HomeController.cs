using System.Web.Mvc;

namespace LuckySpin.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
           return View();
        }
    }
}