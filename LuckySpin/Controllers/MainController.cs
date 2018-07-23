using System.Web.Mvc;
using LuckySpin.Entities;
using LuckySpin.Repositories;

namespace LuckySpin.Controllers
{
    public class MainController : Controller
    {
        public IGameRepository GameRepository = new GameRepository();

        public ActionResult Index()
        {
            var currentTicket = GameRepository.GetActiveVouchers(UserSessionContext.CurrentUser.Customer);

            return View();
        }
    }
}