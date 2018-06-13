using System.Web.Mvc;

namespace LuckySpin.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            /*
             * CREATE TABLE [dbo].[Customer](
               [CustomerId] [int] IDENTITY(1,1)NOT NULL,
               [Username] [varchar](50) NOT NULL,
               [Password] [varbinary](1024) NOT NULL,
               CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED
               (
               [CustomerID] ASC
               )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
               ) ON [PRIMARY]
               
               GO
             */
            /*PasswordHash hash = new PasswordHash("password");
            byte[] hashBytes = hash.ToArray();
            CustomerRepository.CreateCustomer(new Customer(){ Username = "user", Password = hashBytes});*/
            return View();
        }
    }
}