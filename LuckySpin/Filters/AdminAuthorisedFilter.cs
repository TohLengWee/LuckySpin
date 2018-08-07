using System;
using System.Web.Mvc;
using LuckySpin.Entities;

namespace LuckySpin.Filters
{
    public class AdminAuthorisedFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (UserSessionContext.CurrentUser == null || !UserSessionContext.CurrentUser.Customer.IsAdminRole())
            {
                throw new UnauthorizedAccessException();
            }

            base.OnActionExecuting(filterContext);
        }
    }
}