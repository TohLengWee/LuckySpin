using LuckySpin.Entities;

namespace LuckySpin.Repositories
{
    public interface ICustomerRepository
    {
        Customer GetCustomerByUsername(string username);
    }
}