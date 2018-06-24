using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using LuckySpin.Entities;

namespace LuckySpin.Filters
{
    public class LoginFilter: ActionFilterAttribute, IActionFilter
    {
        void IActionFilter.OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (UserSessionContext.CurrentUser is null)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary
                {
                    { "action", "Index"},
                    { "controller", "Login" }
                });
            }
        }
    }
}