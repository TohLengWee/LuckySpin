using System.Collections;
using System.Collections.Generic;
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
            var sql = "Insert Into Customer (Username, Password, BillNumber, Bank, PhoneNumber, Status, CreatedOn, ModifiedOn)" +
                      "Values (@Username, @Password, @BillNumber, @Bank, @PhoneNumber, 0, GETDATE(), GETDATE());";
            return _db.Execute(sql, customer) == 1;
        }

        public Customer GetCustomerByUsername(string username)
        {
            var sql = "SELECT [CustomerID],[Username],[Password], [BillNumber], [Bank], [PhoneNumber], [Status], [CreatedOn], [ModifiedOn] FROM [Customer] WHERE username = @username";
            return _db.Query<Customer>(sql, new {username}).SingleOrDefault();
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            var sql =
                "SELECT [CustomerID],[Username],[Password], [BillNumber], [Bank], [PhoneNumber], [Status], [CreatedOn], [ModifiedOn]  FROM [Customer]";
            return _db.Query<Customer>(sql);
        }

        public bool ToggleSuspend(int customerId)
        {
            var sql = "Update Customer Set Status = Status ^ 2 Where CustomerID = @customerId";
            return _db.Execute(sql, new {customerId}) == 1;
        }
    }
}