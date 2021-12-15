using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;

namespace ProductsAndCategories.Models
{
    public class Product 
    {
        [Key]
        public int ProductId { get; set; }

        [Display(Name = "Name of Product")]
        [Required]
        public string Name { get; set; }

        
        [Display(Name = "Description of Product: ")]
        [Required]
        public string Description { get; set; }

        [Display (Name = "Price: ")]
        [Range(0.01, 100000000)]
        [DataType(DataType.Currency)]
        [Required]
        public Decimal Price { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt{ get; set; } = DateTime.Now;

        //navigation property for the many to many between products and categories
        public List <Association> Categories { get; set; }
    }
}