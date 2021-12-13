using System;
using System.ComponentModel.DataAnnotations;

namespace LoginAndReg.Models
{
    public class LoginUser
    {
        [Display(Name = "Email")]
        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }
    }
}