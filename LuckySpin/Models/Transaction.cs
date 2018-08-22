using System;
using LuckySpin.Controllers;
using LuckySpin.Enums;

namespace LuckySpin.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public int VoucherId { get; set; }
        public int CustomerId { get; set; }
        public int Prize { get; set; }
        public TransactionStatus Status { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public DateTime TransactionTime { get; set; }
    }
}