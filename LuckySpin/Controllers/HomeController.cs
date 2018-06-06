using System;
using System.Web.Mvc;
using LuckySpin.Entities;
using LuckySpin.Repositories;

namespace LuckySpin.Controllers
{
    public class HomeController : Controller
    {
        public IAccountDb AccountDb { get; set; }

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
                var customer = AccountDb.Login(form);
                UserSessionContext.CurrentUser = new UserSession {Customer = customer};
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index", "Main");
        }
    }
}