using System;
using System.Linq;
using System.Web.Mvc;
using LuckySpin.Entities;
using LuckySpin.Models.Game;
using LuckySpin.Repositories;

namespace LuckySpin.Controllers
{
    public class MainController : Controller
    {
        public IGameRepository GameRepository = new GameRepository();

        public ActionResult Index()
        {
            var vouchers = GameRepository.GetActiveVouchers(UserSessionContext.CurrentUser.Customer);
            Voucher currentVoucher = new Voucher(){ SpinCount = 0};
            if (vouchers != null && vouchers.Count > 0)
            {
                currentVoucher = vouchers.OrderBy(x => x.ExpiryOn).First();
            }

            return View("Index", new GamePlayViewModel()
            {
                Voucher = currentVoucher
            });
        }

        public JsonResult GetSpinResult()
        {

            ////TODO: check remaining spin count before continue, if 0 then need to handle in front end as well
            return Json(new {prize = DateTime.Now.Millisecond % 4 * 5  % 15 + 1 }, JsonRequestBehavior.AllowGet);
        }
    }

    public class GamePlayViewModel
    {
        public Voucher Voucher { get; set; }
    }
}