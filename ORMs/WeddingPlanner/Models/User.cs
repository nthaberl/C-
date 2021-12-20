using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; //lets us use [NotMapped]

namespace WeddingPlanner.Models
{
    public class User
    {
        [Key]
        public int UserId {get; set;}

        [Display(Name = "First Name: ")]
        [MinLength (2, ErrorMessage = "First name must be at least 2 characters")]
        [RegularExpression("^[A-Za-z ]+$", ErrorMessage = "Name can only contain letters and spaces")]
        [Required (ErrorMessage = "Please enter your first name")]
        public string FirstName { get; set; }
        


        [Display(Name = "Last Name: ")]
        [MinLength (2, ErrorMessage = "Last name must be at least 2 characters")]
        [RegularExpression("^[A-Za-z ]+$", ErrorMessage = "Name can only contain letters and spaces")]
        [Required (ErrorMessage = "Please enter your last name")]
        public string LastName { get; set;}



        [Display(Name = "Email: ")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please provide an email address")]
        public string Email { get; set; }



        [Display(Name = "Password: ")]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters long!")]
        [Required]
        public string Password { get; set; }



        [NotMapped]
        [Display(Name = "Confirm Password: ")]
        [Compare("Password", ErrorMessage = "Passwords must match!")]
        [DataType(DataType.Password)]
        public string Confirm { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt {get; set; } = DateTime.Now;

        public List<Wedding> WeddingsMade { get; set; }
    }
}