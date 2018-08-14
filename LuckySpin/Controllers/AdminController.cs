using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;
using LuckySpin.Entities;
using LuckySpin.Filters;
using LuckySpin.Models.Game;
using LuckySpin.Models.ViewModels;
using LuckySpin.Repositories;

namespace LuckySpin.Controllers
{
    [LoginFilter]
    [AdminAuthorisedFilter]
    public class AdminController : BaseController
    {
        private readonly ICustomerRepository _customerRepository = new CustomerRepository();
        private readonly IGameRepository _gameRepository = new GameRepository();

        public ActionResult Index()
        {
            List<Customer> adminList = _customerRepository.GetAllCustomers().Where(x => x.IsAdminRole()).ToList();
            return View("MembersList", adminList);
        }

        public ActionResult MembersList()
        {
            List<Customer> customers = _customerRepository.GetAllCustomers().Where(x=>!x.IsAdminRole()).ToList();
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
        public ActionResult AddVoucher(Voucher voucher)
        {
            _gameRepository.AddVoucher(voucher);
            var customer = _customerRepository.GetCustomerByCustomerId(voucher.CustomerId);
            return RedirectToAction("MemberDetail", new RouteValueDictionary {{"username", customer.Username}});
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