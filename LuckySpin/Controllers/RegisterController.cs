using System.Web.Mvc;
using LuckySpin.Models.Register;

namespace LuckySpin.Controllers
{
    public class RegisterController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Registration registration)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", registration);
            }
            return RedirectToAction("Index", "Home");
        }
    }
}