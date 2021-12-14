using System.Collections.Generic;

namespace ChefsAndDishes.Models
{
    public class NewDishView
    {
        public Dish newDish { get; set; }
        public List <Chef> AllChefs { get; set; }
    }
}