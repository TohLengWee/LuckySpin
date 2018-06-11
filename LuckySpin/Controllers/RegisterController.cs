using System.Web.Mvc;
using LuckySpin.Entities;
using LuckySpin.Helpers;
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
            if (!ModelState.IsValid || !UsernameAvailability(registration.Username))
            {
                return View("Index", registration);
            }

            var customer = ConstructCustomer(registration);
            _customerRepository.CreateCustomer(customer);

            return RedirectToAction("Index", "Home");
        }

        private bool UsernameAvailability(string username)
        {
            return _customerRepository.GetCustomerByUsername(username) == null;
        }

        private static Customer ConstructCustomer(Registration registration)
        {
            var hash = new PasswordHash(registration.Password);
            byte[] hashBytes = hash.ToArray();

            var customer = new Customer
            {
                Password = hashBytes,
                BillNumber = registration.BillNumber,
                Username = registration.Username,
                PhoneNumber = registration.PhoneNumber,
                Bank = (int)registration.Bank
            };
            return customer;
        }
    }
}