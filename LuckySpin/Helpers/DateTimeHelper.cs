using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LuckySpin.Helpers
{
    public static class DateTimeHelper
    {
        public static DateTime GetNow(this DateTime now)
        {
            var offset = now - now.ToUniversalTime();
            if (offset.Hours == 8)
            {
                return now;
            }

            return now.ToUniversalTime().AddHours(7);
        }
    }
}