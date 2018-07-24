using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using LuckySpin.Entities;
using LuckySpin.Models.ViewModels;
using LuckySpin.Repositories;

namespace LuckySpin.Controllers
{
    public class AdminController : Controller
    {
        private readonly ICustomerRepository _customerRepository = new CustomerRepository();
        private readonly IGameRepository _gameRepository = new GameRepository();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MembersList()
        {
            List<Customer> customers = _customerRepository.GetAllCustomers().ToList();
            return View(customers);
        }

        public ActionResult MemberDetail(string username)
        {
            var customer = _customerRepository.GetCustomerByUsername(username);
            var viewModel = new MemberDetailViewModel()
            {
                Customer = customer,
                Vouchers = _gameRepository.GetActiveVouchers(customer)
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult ToggleSuspend(int customerId)
        {
            var success = _customerRepository.ToggleSuspend(customerId);
            return Json(new {Success = success});
        }

        [HttpPost]
        public ActionResult ActivateCustomer(int customerId)
        {
            var success = _customerRepository.ActivateCustomer(customerId);
            return Json(new {Success = success});            
        }
    }
}