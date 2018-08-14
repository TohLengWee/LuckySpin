using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using LuckySpin.Entities;
using LuckySpin.Filters;
using LuckySpin.Models.Game;
using LuckySpin.Repositories;

namespace LuckySpin.Controllers
{
    [LoginFilter]
    public class MainController : BaseController
    {
        public IGameRepository GameRepository = new GameRepository();

        public ActionResult Index()
        {
            var vouchers = GameRepository.GetActiveVouchers(UserSessionContext.CurrentUser.Customer);
            if (vouchers is null)
            {
                vouchers = new List<Voucher>();
            }

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

        public JsonResult GetSpinResult(int voucherId)
        {
            var voucher = GameRepository.GetVoucherById(voucherId, UserSessionContext.CurrentUser.Customer);

            if (voucher is null)
            {
                TempData["Error"] = "Voucher is not valid.";
                return Json(new {status = "error", msg= "Voucher is not valid." });
            }

            if (voucher.SpinCount <= 0)
            {
                TempData["Error"] = "There is no spin remaining in the voucher.";
                return Json(new {status = "error", msg= "There is no spin remaining in the voucher." });
            }
            
            GameRepository.ReduceSpinCountByVoucherId(voucherId, UserSessionContext.CurrentUser.Customer);

            voucher = GameRepository.GetVoucherById(voucherId, UserSessionContext.CurrentUser.Customer);

            return Json(new {prize = DateTime.Now.Millisecond % 4 * 5, status="success", remainingCount = voucher.SpinCount }, JsonRequestBehavior.AllowGet);
        }
    }

    public class GamePlayViewModel
    {
        public Voucher Voucher { get; set; }
        public Customer Customer { get; set; }
    }
}