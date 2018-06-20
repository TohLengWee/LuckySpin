using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using LuckySpin.Entities;
using LuckySpin.Repositories;

namespace LuckySpin.Controllers
{
    public class AdminController : Controller
    {
        private readonly ICustomerRepository _customerRepository = new CustomerRepository();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MembersList()
        {
            List<Customer> customers = _customerRepository.GetAllCustomers().ToList();
            return View(customers);
        }

        [HttpPost]
        public ActionResult ToggleSuspend(int customerId)
        {
            var success = _customerRepository.ToggleSuspend(customerId);
            return Json(new {Success = success});
        }
    }
}