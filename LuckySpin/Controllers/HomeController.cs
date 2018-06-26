using System.Web.Mvc;
using LuckySpin.Filters;

namespace LuckySpin.Controllers
{
    [LoginFilter]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}