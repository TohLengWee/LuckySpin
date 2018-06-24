using System;

namespace LuckySpin.Models.Game
{
    public class Ticket
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int SpinCount { get; set; }
        public int MaxWinning { get; set; }
        public int SpinBoard { get; set; }
        public DateTime ExpiryOn { get; set; }
        public int Status { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}