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
        private readonly IDbConnection _db = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

        public bool CreateCustomer(Customer customer)
        {
            var sql = "Insert Into Customer (Username, Password, BillNumber, Bank, PhoneNumber, CreatedOn, ModifiedOn)" +
                      "Values (@Username, @Password, @BillNumber, @Bank, @PhoneNumber, GETDATE(), GETDATE());";
            return _db.Execute(sql, customer) == 1;
        }

        public Customer GetCustomerByUsername(string username)
        {
            var sql = "SELECT [CustomerID],[Username],[Password] FROM [Customer] WHERE username = @username";
            return _db.Query<Customer>(sql, new {username}).SingleOrDefault();
        }
    }
}