using System;
using System.Web.Mvc;
using LuckySpin.Entities;
using LuckySpin.Helpers;
using LuckySpin.Repositories;

namespace LuckySpin.Controllers
{
    public class LoginController : BaseController
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

                if (!customer.IsActivated() || customer.IsSuspended())
                {
                    throw new UnauthorizedAccessException("Account yang tak sah.");
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

            var url = GetMainPageBasedOnRole(UserSessionContext.CurrentUser);
            return Json(new {Success = true, Url = url, Message = string.Empty});
        }

        private string GetMainPageBasedOnRole(UserSession currentUser)
        {
            return currentUser.Customer.IsAdminRole() ? Url.Action("MembersList", "Admin"): Url.Action("Index", "Main");
        }
    }
}