using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Security;
using LuckySpin.Enums;

namespace LuckySpin.Models.Register
{
    public class Registration
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [PasswordPropertyText]
        [DataType(DataType.Password)]
        [StringLength(255, MinimumLength = 7)]
        //[RegularExpression(@"^(?=.{7})(?=.*\W)", ErrorMessage = "At least 7 characters and 1 special character")]
        [MembershipPassword]
        public string Password { get; set; }

        [Required]
        [NotMapped]
        [DisplayName("Verifikasi Password")]
        [Compare("Password")]
        [MembershipPassword]
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