using System;

namespace RestaurentProject.ViewModel
{
    public class MenuViewModel
    {
        public string MealName { get; set; }
        public float PriceInNis { get; set; }
        public int Quantity { get; set; }
        public int RestaurantId { get; set; }
    }
}
