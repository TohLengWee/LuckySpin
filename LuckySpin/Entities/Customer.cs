using LuckySpin.Enums;

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
    }
}