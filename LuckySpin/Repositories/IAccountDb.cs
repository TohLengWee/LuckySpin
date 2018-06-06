using LuckySpin.Entities;

namespace LuckySpin.Repositories
{
    public interface IAccountDb
    {
        Customer Login(LoginForm form);
    }

    public class AccountDb : IAccountDb
    {
        public Customer Login(LoginForm form)
        {
            throw new System.NotImplementedException();
        }
    }
}