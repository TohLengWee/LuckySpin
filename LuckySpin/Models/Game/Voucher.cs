using System;
using System.Collections.Generic;
using LuckySpin.Enums;
using Newtonsoft.Json;

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
        public bool Status { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }

        public Dictionary<int, int> WinningDetails => JsonConvert.DeserializeObject<Dictionary<int, int>>(Winning);
    }
}