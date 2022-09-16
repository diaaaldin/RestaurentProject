using System;
using System.Collections.Generic;

#nullable disable

namespace RestaurentProject.Models
{
    public partial class ExportDatum
    {
        public string RestaurentName { get; set; }
        public int CustomerId { get; set; }
        public float PriceInUsd { get; set; }
        public float PriceInNis { get; set; }
        public string MealName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
