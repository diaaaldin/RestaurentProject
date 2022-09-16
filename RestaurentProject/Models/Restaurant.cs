using System;
using System.Collections.Generic;

#nullable disable

namespace RestaurentProject.Models
{
    public partial class Restaurant
    {
        public Restaurant()
        {
            RestaurentMenus = new HashSet<RestaurentMenu>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool Archived { get; set; }

        public virtual ICollection<RestaurentMenu> RestaurentMenus { get; set; }
    }
}
