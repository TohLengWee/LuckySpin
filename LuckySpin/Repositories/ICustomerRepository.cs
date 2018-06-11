using LuckySpin.Entities;

namespace LuckySpin.Repositories
{
    public interface ICustomerRepository
    {
        bool CreateCustomer(Customer c);
        Customer GetCustomerByUsername(string username);
    }
}