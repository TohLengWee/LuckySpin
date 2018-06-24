using System.Web.Mvc;
using LuckySpin.Entities;
using LuckySpin.Filters;
using LuckySpin.Repositories;

namespace LuckySpin.Controllers
{
    [LoginFilter]
    public class HomeController : Controller
    {
        public IGameRepository GameRepository = new GameRepository();

        public ActionResult Index()
        {
            var currentTicket = GameRepository.GetCurrentTicket(UserSessionContext.CurrentUser.Customer);

            return View();
        }
    }
}