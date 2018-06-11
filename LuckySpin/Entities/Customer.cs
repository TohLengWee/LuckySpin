using LuckySpin.Helpers;
using LuckySpin.Models.Register;

namespace LuckySpin.Entities
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Username { get; set; }
        public byte[] Password { get; set; }
        public string BillNumber { get; set; }
        public int Bank { get; set; }
        public string PhoneNumber { get; set; }

        public Customer(){}

        public Customer(Registration registration)
        {
            var hash = new PasswordHash(registration.Password);
            var hashBytes = hash.ToArray();

            Password = hashBytes;
            BillNumber = registration.BillNumber;
            Username = registration.Username;
            PhoneNumber = registration.PhoneNumber;
            Bank = (int) registration.Bank;
        }
    }
}