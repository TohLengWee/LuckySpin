using System.Web.Mvc;
using LuckySpin.Entities;
using LuckySpin.Models.Register;
using LuckySpin.Repositories;

namespace LuckySpin.Controllers
{
    public class RegisterController : Controller
    {
        private readonly ICustomerRepository _customerRepository = new CustomerRepository();

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

            var customer = new Customer
            {
                Password = new byte[] {201},
                BillNumber = registration.BillNumber,
                Username = registration.Username,
                PhoneNumber = registration.PhoneNumber,
                Bank = (int)registration.Bank
            };

            _customerRepository.CreateCustomer(customer);

            return RedirectToAction("Index", "Home");
        }
    }
}