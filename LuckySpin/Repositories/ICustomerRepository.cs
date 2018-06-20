using System.Collections.Generic;
using LuckySpin.Entities;

namespace LuckySpin.Repositories
{
    public interface ICustomerRepository
    {
        bool CreateCustomer(Customer customer);
        Customer GetCustomerByUsername(string username);
        IEnumerable<Customer> GetAllCustomers();
        bool ToggleSuspend(int customerId);
    }
}