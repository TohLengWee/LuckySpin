using System.Web.Mvc;
using LuckySpin.Filters;
using LuckySpin.Services;

namespace LuckySpin.Controllers
{
    [GeneralExceptionFilter]
    public class BaseController : Controller
    {
        public ILogger Logger = new Logger();
    }
}