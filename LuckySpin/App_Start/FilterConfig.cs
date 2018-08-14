using System.Web.Mvc;
using LuckySpin.Filters;

namespace LuckySpin
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new GeneralExceptionFilter());
        }
    }
}
