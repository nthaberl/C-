using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace ChefsAndDishes.Models
{
    public class Dish
    {
        [Key]
        public int DishId { get; set; }

        [Display (Name = "Name of Dish: ")]
        [Required (ErrorMessage = "Please provide a name for the dish")]
        public string DishName { get; set; }

        [Display (Name = "Calorie Amount: ")]
        [Range(0,5000, ErrorMessage = "Please provide a valid number")]
        [Required(ErrorMessage = "Please provide a calorie amount, an estimate is fine")]
        public int Calories { get; set; }

        [Display(Name = "Tastiness: ")]
        [Range(1, 5)]
        [Required(ErrorMessage = "Please rate the tastiness of this dish")]
        public int Tastiness { get; set; }

        [Display(Name = "Description: ")]
        [Required(ErrorMessage = "Please provide a description")]
        public string Description { get; set; }

        [Display(Name = "Created by: ")]
        //will find the foreign key for the chef who created the dish
        public int ChefId {get; set;}
        //navigation property for the actual chef
        public Chef CreatedBy { get; set; }

        public DateTime CreatedAt {get; set;} = DateTime.Now;
        public DateTime UpdatedAt {get; set;} = DateTime.Now;

        [NotMapped]
        //exclusively for the form
        public List<Chef> AllChefs { get; set; }
    }
}
