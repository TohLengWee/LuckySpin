using System;
using System.Web.Mvc;
using LuckySpin.Entiies;

namespace LuckySpin.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginForm form)
        {
            try
            {
                form.Validate();

            }
            catch (Exception exception)
            {
                return Json(new { Result = "Failed", Message = exception.Message });
            }

            return RedirectToAction("Index");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}