using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; //lets us use [NotMapped]

namespace LoginAndReg.Models
{
    public class User
    {
        [Key]
        public int UserId {get; set;}

        [Display(Name = "First Name: ")]
        [MinLength (2, ErrorMessage = "First name must be at least 2 characters")]
        [Required]
        public string FirstName { get; set; }
        
        [Display(Name = "Last Name: ")]
        [MinLength (2, ErrorMessage = "Last name must be at least 2 characters")]
        [Required]
        public string LastName { get; set;}

        [Display(Name = "Email: ")]
        [EmailAddress (ErrorMessage = "Email address is required")]
        [Required]
        public string Email { get; set; }

        [Display(Name = "Password: ")]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters long!")]
        [Required]
        public string Password { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt {get; set; } = DateTime.Now;

        [NotMapped]
        [Display(Name = "Confirm Password")]
        [Compare("Password")]
        [DataType(DataType.Password)]
        public string Confirm { get; set; }
    }
}