using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using LuckySpin.Entities;
using LuckySpin.Filters;
using LuckySpin.Models;
using LuckySpin.Models.Game;
using LuckySpin.Models.ViewModels;
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
            var transaction = new Transaction
            {
                VoucherId = voucherId,
                CustomerId = UserSessionContext.CurrentUser.Customer.CustomerId,
                Prize = 0,
                CreatedOn = DateTime.Now,
                ModifiedOn = DateTime.Now
            };
            GameRepository.AddTransaction(transaction);
            voucher = GameRepository.GetVoucherById(voucherId, UserSessionContext.CurrentUser.Customer);

            return Json(new {prize = DateTime.Now.Millisecond % 4 * 5, status="success", result=0, remainingCount = voucher.SpinCount }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult TransactionHistory()
        {
            var transactions = GameRepository.GetTransactionHistory(UserSessionContext.CurrentUser.Customer).OrderByDescending(x=>x.TransactionTime).ToList();

            return View(transactions);
        }
    }
}