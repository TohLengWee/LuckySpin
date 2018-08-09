using System;
using System.Linq;
using System.Web.Mvc;
using LuckySpin.Entities;
using LuckySpin.Filters;
using LuckySpin.Models.Game;
using LuckySpin.Repositories;

namespace LuckySpin.Controllers
{
    [LoginFilter]
    public class MainController : Controller
    {
        public IGameRepository GameRepository = new GameRepository();

        public ActionResult Index()
        {
            var vouchers = GameRepository.GetActiveVouchers(UserSessionContext.CurrentUser.Customer);

            return View("Index", vouchers);
        }

        public ActionResult Game(int voucherId)
        {
            var voucher = GameRepository.GetVoucherById(voucherId, UserSessionContext.CurrentUser.Customer);

            if (voucher is null)
            {
                TempData["Error"] = "Voucher is not valid.";
                return RedirectToAction("Index");
            }

            return View("Game", new GamePlayViewModel()
            {
                Voucher = voucher,
                Customer = UserSessionContext.CurrentUser.Customer
            });
        }

        public JsonResult GetSpinResult()
        {
            var vouchers = GameRepository.GetActiveVouchers(UserSessionContext.CurrentUser.Customer);
            Voucher currentVoucher = new Voucher();
            if (vouchers != null && vouchers.Count > 0)
            {
                currentVoucher = vouchers.OrderBy(x => x.ExpiryOn).First();
            }

            return Json(new {prize = DateTime.Now.Millisecond % 4 * 5  % 15 + 1, status="success" }, JsonRequestBehavior.AllowGet);
        }
    }

    public class GamePlayViewModel
    {
        public Voucher Voucher { get; set; }
        public Customer Customer { get; set; }
    }
}