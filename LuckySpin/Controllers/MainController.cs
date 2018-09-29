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
        public Dictionary<int, string> PrizeDetail = new Dictionary<int, string>()
        {
            {1, "ZONK"}, {2, "150K"}, {3, "50K"}, {4, "75K"}, {5, "100K"},
            {6, "ZONK"}, {7, "350K"}, {8, "10K"}, {9, "25K"}, {10, "35K"}
        };

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

            var prize = voucher.WinningDetails[voucher.SpinCount];

            GameRepository.ReduceSpinCountByVoucherId(voucherId, UserSessionContext.CurrentUser.Customer);
            var transaction = new Transaction
            {
                VoucherId = voucherId,
                CustomerId = UserSessionContext.CurrentUser.Customer.CustomerId,
                Prize = prize,
                CreatedOn = DateTime.Now,
                ModifiedOn = DateTime.Now
            };
            GameRepository.AddTransaction(transaction);

            voucher = GameRepository.GetVoucherById(voucherId, UserSessionContext.CurrentUser.Customer);

            return Json(new {prize = (prize-1) + DateTime.Now.Millisecond % 2 * (prize == 1 ?5 : 10), status="success", result=prize==1 || prize == 6?0:1, remainingCount = voucher.SpinCount, prizeDetail = PrizeDetail[prize] }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult TransactionHistory()
        {
            var transactions = GameRepository.GetTransactionHistory(UserSessionContext.CurrentUser.Customer).OrderByDescending(x=>x.TransactionTime).ToList();

            return View(transactions);
        }
    }
}