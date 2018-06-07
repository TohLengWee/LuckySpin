using System.Web;

namespace LuckySpin.Entities
{
    public class UserSessionContext
    {
        public static UserSession CurrentUser
        {
            get
            {
                if (HttpContext.Current.Session[UserSession.SessionName] == null)
                {
                    return null;
                }
                return (UserSession)HttpContext.Current.Session[UserSession.SessionName];
            }
            set { HttpContext.Current.Session[UserSession.SessionName] = value; }
        }
    }
}