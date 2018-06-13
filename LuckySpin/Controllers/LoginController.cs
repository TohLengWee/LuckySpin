using System;
using System.Web.Mvc;
using LuckySpin.Entities;
using LuckySpin.Helpers;
using LuckySpin.Repositories;

namespace LuckySpin.Controllers
{
    public class LoginController : Controller
    {
        public ICustomerRepository CustomerRepository = new CustomerRepository();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginForm form)
        {
            try
            {
                form.Validate();

                var customer = CustomerRepository.GetCustomerByUsername(form.Username);
                if (customer == null)
                {
                    throw new UnauthorizedAccessException("Username/password yang tak sah.");
                }

                byte[] hashBytes = customer.Password;
                var hash = new PasswordHash(hashBytes);
                if (!hash.Verify(form.Password))
                    throw new UnauthorizedAccessException("Username/password yang tak sah.");

                UserSessionContext.CurrentUser = new UserSession { Customer = customer };
            }
            catch (Exception ex)
            {
                return Json(new {Success = false, Url = string.Empty, Message = ex.Message});
            }

            return Json(new {Success = true, Url = Url.Action("Index", "Main"), Message = string.Empty});
        }
    }
}