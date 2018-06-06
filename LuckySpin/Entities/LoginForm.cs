using System;

namespace LuckySpin.Entities
{
    public class LoginForm
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public void Validate()
        {
            if (string.IsNullOrEmpty(Username)) { throw new ArgumentException("Invalid username"); }

            if (string.IsNullOrEmpty(Password))
            {
                throw new ArgumentException("Invalid username/ password");
            }
        }
    }
}