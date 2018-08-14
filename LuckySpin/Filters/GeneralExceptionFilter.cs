using System.Web.Mvc;
using LuckySpin.Services;

namespace LuckySpin.Filters
{
    public class GeneralExceptionFilter : HandleErrorAttribute
    {
        public ILogger Logger = new Logger();

        public override void OnException(ExceptionContext filterContext)
        {
            Logger.Error($"Exception occurred : {filterContext.Exception}");
            filterContext.ExceptionHandled = true;
            filterContext.Result = new RedirectResult("/Error");
            base.OnException(filterContext);
        }
    }
}