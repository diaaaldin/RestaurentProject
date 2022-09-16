using System;
using System.Collections.Generic;

#nullable disable

namespace RestaurentProject.Models
{
    public partial class RestaurentMenu
    {
        public RestaurentMenu()
        {
            CustomerMenus = new HashSet<CustomerMenu>();
        }

        public int Id { get; set; }
        public string MealName { get; set; }
        public float PriceInNis { get; set; }
        public float PriceInUsd { get; set; }
        public int Quantity { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool Archived { get; set; }  
        public int RestaurantId { get; set; }

        public virtual Restaurant Restaurant { get; set; }
        public virtual ICollection<CustomerMenu> CustomerMenus { get; set; }
    }
}
