using System.Collections.Generic;

namespace ProductsAndCategories.Models
{
    public class CategoryInfoView
    {
        public Category ToRender { get; set; }
        public List<Product> ToAdd { get; set; }
        public Association AddForm { get; set; }
    }
}