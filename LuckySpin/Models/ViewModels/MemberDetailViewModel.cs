using System.Collections.Generic;
using LuckySpin.Entities;
using LuckySpin.Models.Game;

namespace LuckySpin.Models.ViewModels
{
    public class MemberDetailViewModel
    {
        public Customer Customer { get; set; }
        public List<Ticket> Tickets { get; set; }
    }
}