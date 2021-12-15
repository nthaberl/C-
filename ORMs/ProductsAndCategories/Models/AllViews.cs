using System.Collections.Generic;

namespace ProductsAndCategories.Models
{
    public class AllViews
    {
        public List<Product> AllProducts { get; set; }
        public Product newProduct { get; set; }
        public List<Category> AllCategories {get; set; }
        public Category newCategory { get; set; }
        public List<Association> AllAssociations { get; set; }
        public Association newAssociation { get; set; }

    }

}