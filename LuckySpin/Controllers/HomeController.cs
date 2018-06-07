using System;
using System.Web.Mvc;
using LuckySpin.Entities;
using LuckySpin.Helpers;
using LuckySpin.Repositories;

namespace LuckySpin.Controllers
{
    public class HomeController : Controller
    {
        public ICustomerRepository CustomerRepository = new CustomerRepository();
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

                var customer = CustomerRepository.GetCustomerByUsername(form.Username);
                if (customer == null)
                {
                    throw new UnauthorizedAccessException();
                }

                byte[] hashBytes = customer.Password;
                var hash = new PasswordHash(hashBytes);
                if (!hash.Verify(form.Password))
                    throw new UnauthorizedAccessException();

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