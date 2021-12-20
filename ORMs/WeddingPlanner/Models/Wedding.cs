using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; //lets us use [NotMapped]

namespace WeddingPlanner.Models
{
    public class Wedding
    {
        [Key]
        public int WeddingId {get; set;}

        [Display(Name = "Wedder One Name: ")]
        [MinLength (2, ErrorMessage = "First name must be at least 2 characters")]
        [Required]
        public string FirstWedder { get; set; }
        
        [Display(Name = "Wedder Two Name: ")]
        [MinLength (2, ErrorMessage = "Last name must be at least 2 characters")]
        [Required]
        public string SecondWedder { get; set;}

        [Display(Name = "Date of Wedding: ")]
        [DataType(DataType.Date)]
        [FutureDate]
        [Required]
        public string WeddingDate { get; set; }

        [Display(Name = "Wedding Address: ")]
        [EmailAddress (ErrorMessage = "An address is required")]
        [Required]
        public string Address { get; set; }

        public int UserId { get; set; }
        public User CreatedBy { get; set; }

        public List<RSVP> RSVPList { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt {get; set; } = DateTime.Now;




        // Custom Validation //
        public class FutureDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime datetime;
            // safely unbox value to DateTime
            if(value is DateTime)
                datetime = (DateTime)value;
            else
                return new ValidationResult("Invalid datetime");
            
            if(datetime < DateTime.Now)
                return new ValidationResult("Date must be prior to today");

            return ValidationResult.Success;
            }
        }
    }
}