using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;
using LuckySpin.Controllers;

namespace LuckySpin.Models.Register
{
    public class Registration
    {
        [Required]
        public string Username { get; set; }
        [Required]
        [PasswordPropertyText]
        [RegularExpression(@"^(?=.{8})(?=.*\W)")]
        public string Password { get; set; }
        [Required]
        [NotMapped]
        [DisplayName("Verifikasi Password")]
        [System.ComponentModel.DataAnnotations.Compare("Password")]
        public string ConfirmPassword { get; set; }
        [Required]
        [DisplayName("Nomor Rekening")]
        public string BillNumber { get; set; }
        [Required]
        [EnumDataType(typeof(Bank))]
        public Bank? Bank { get; set; }
        [Required]
        [DisplayName("Nomor Hp")]
        public string PhoneNumber { get; set; }
    }
}