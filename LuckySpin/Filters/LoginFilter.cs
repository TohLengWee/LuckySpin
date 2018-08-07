using System.Web.Mvc;
using System.Web.Routing;
using LuckySpin.Entities;

namespace LuckySpin.Filters
{
    public class LoginFilter: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (UserSessionContext.CurrentUser is null)
            {
                filterContext.HttpContext.Session.Abandon();
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary
                {
                    { "action", "Index"},
                    { "controller", "Home" }
                });
            }

            base.OnActionExecuting(filterContext);
        }
    }
}