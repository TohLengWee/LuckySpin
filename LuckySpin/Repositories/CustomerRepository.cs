using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using LuckySpin.Entities;

namespace LuckySpin.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private IDbConnection _db = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

        public Customer GetCustomerByUsername(string username)
        {
            var sql = "SELECT[CustomerID],[Username] FROM [Customer] WHERE username = @username";
            return _db.Query<Customer>(sql, new { username = username }).SingleOrDefault();
        }
    }
}