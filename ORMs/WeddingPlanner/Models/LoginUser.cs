using System;
using System.ComponentModel.DataAnnotations;

namespace WeddingPlanner.Models
{
    public class LoginUser
    {
        [Display(Name = "Email: ")]
        [EmailAddress]
        [Required(ErrorMessage = "Please enter your email!")]
        public string LoginEmail { get; set; }

        [Display(Name = "Password: ")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Please enter your password!")]
        public string LoginPassword { get; set; }
    }
}