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
            /*
             * CREATE TABLE [dbo].[Customer](
               [CustomerId] [int] IDENTITY(1,1)NOT NULL,
               [Username] [varchar](50) NOT NULL,
               [Password] [varbinary](1024) NOT NULL,
               CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED
               (
               [CustomerID] ASC
               )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
               ) ON [PRIMARY]
               
               GO
             */
            /*PasswordHash hash = new PasswordHash("password");
            byte[] hashBytes = hash.ToArray();
            CustomerRepository.CreateCustomer(new Customer(){ Username = "user", Password = hashBytes});*/
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
                    throw new UnauthorizedAccessException("Invalid username/password");
                }

                byte[] hashBytes = customer.Password;
                var hash = new PasswordHash(hashBytes);
                if (!hash.Verify(form.Password))
                    throw new UnauthorizedAccessException("Invalid username/password");

                UserSessionContext.CurrentUser = new UserSession {Customer = customer};
            }
            catch (Exception ex)
            {
                ViewBag["Error"] = ex.Message;
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index", "Main");
        }
    }
}