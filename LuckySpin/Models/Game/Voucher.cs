using System;
using LuckySpin.Enums;

namespace LuckySpin.Models.Game
{
    public class Voucher
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int SpinCount { get; set; }
        public string Winning { get; set; }
        public SpinBoardType SpinBoard { get; set; }
        public DateTime ExpiryOn { get; set; }
        public int Status { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}