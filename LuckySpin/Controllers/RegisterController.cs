using System.Web.Mvc;
using LuckySpin.Entities;
using LuckySpin.Models.Register;
using LuckySpin.Repositories;

namespace LuckySpin.Controllers
{
    public class RegisterController : BaseController
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

            var customer = new Customer(registration);
            _customerRepository.CreateCustomer(customer);

            return RedirectToAction("Index", "Home");
        }

        private bool UsernameAvailability(string username)
        {
            return _customerRepository.GetCustomerByUsername(username) == null;
        }
    }
}