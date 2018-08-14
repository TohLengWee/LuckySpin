using System.Web.Mvc;
using LuckySpin.Services;

namespace LuckySpin.Controllers
{
    public class BaseController : Controller
    {
        public ILogger Logger = new Logger();
    }
}