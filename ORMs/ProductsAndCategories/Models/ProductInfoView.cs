using System.Collections.Generic;

namespace ProductsAndCategories.Models
{
    public class ProductInfoView
    {
        public Product ToRender { get; set; }
        public List<Category> ToAdd { get; set; }
        public Association AddForm { get; set; }
    }
}