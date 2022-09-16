using System;
using System.Collections.Generic;

#nullable disable

namespace RestaurentProject.Models
{
    public partial class CustomerMenu
    {
        public int CustomerId { get; set; }
        public int RestaurentMenuId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual RestaurentMenu RestaurentMenu { get; set; }
    }
}
