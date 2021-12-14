using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System;

namespace ChefsAndDishes.Models
{
    public class Chef
    {
        [Key]
        public int ChefId { get; set; }

        [Display(Name = "First Name: ")]
        [Required]

        public string FirstName { get; set; }

        [Display(Name = "Last Name: ")]
        [Required]
        public string LastName { get; set; }

        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        // [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd", ApplyFormatInEditMode = true)]
        [Required]
        [PastDate]
        [MinimumAge(18)]
        public DateTime DOB { get; set;}

        public DateTime CreatedAt {get; set;} = DateTime.Now;
        public DateTime UpdatedAt {get; set;} = DateTime.Now;

        //navigation property for the dishes made by this chef
        // [NotMapped] if not mapped will throw off lambda expression
        public List<Dish> CreatedDishes { get; set; }



        //custom validations
public class PastDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime datetime;
            // safely unbox value to DateTime
            if(value is DateTime)
                datetime = (DateTime)value;
            else
                return new ValidationResult("Invalid datetime");
            
            if(datetime > DateTime.Now)
                return new ValidationResult("Date must be prior to today");

            return ValidationResult.Success;
            }
        }

        public class MinimumAge : ValidationAttribute
    {
        private int _Limit;
        public MinimumAge(int Limit) { // The constructor which we use in model
            this._Limit = Limit;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext) 
        {
                DateTime bday = DateTime.Parse(value.ToString());
                DateTime today = DateTime.Today;
                int age = today.Year - bday.Year;
                if (bday > today.AddYears(-age))
                {
                age--; 
                }
                if (age < _Limit)
                {
                    var result = new ValidationResult("Must be at least 18+");
                    return result; 
                }
            return null;
            }
        }
    }
}