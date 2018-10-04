using System.Collections.Generic;
using LuckySpin.Entities;
using LuckySpin.Models.Game;
using LuckySpin.Repositories;

namespace LuckySpin.Models.ViewModels
{
    public class GamePlayViewModel
    {
        public Voucher Voucher { get; set; }
        public Customer Customer { get; set; }
        public List<TransactionDetail> Transactions { get; set; }
    }
}