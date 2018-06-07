using LuckySpin.Entities;

namespace LuckySpin.Repositories
{
    public interface ICustomerRepository
    {
        bool CreateCustomer(Customer customer);
        Customer GetCustomerByUsername(string username);
    }
}