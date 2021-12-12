using System;
using System.ComponentModel.DataAnnotations;

namespace CRUDelicious.Models
{
    public class Dish
    {
        [Key]
        public int DishId { get; set; }

        [Display (Name = "Name of dish: ")]
        [Required(ErrorMessage = "Please provide a name for the dish")]
        public string Name { get; set; }

        [Display (Name = "Your name (or name of the original chef!): ")]
        [Required(ErrorMessage = "Please provide a name")]
        public string Chef { get; set; }

        [Display (Name= "Rate dish's tastiness! ")]
        [Required]
        public int Tastiness { get; set; }

        [Display (Name = "How Many Calories? ")]
        [Required(ErrorMessage = "Please provide a calorie count, best guess is fine")]
        public int Calories { get; set; }

        [Display (Name = "Please describe the dish! ")]
        [Required]
        public string Description { get; set; }
        public DateTime CreatedAt {get; set;} = DateTime.Now;
        public DateTime UpdatedAt {get; set;} = DateTime.Now;
    }
}