using System;
using System.Collections.Generic;

#nullable disable

namespace RestaurentProject.Models
{
    public partial class Customer
    {
        public Customer()
        {
            CustomerMenus = new HashSet<CustomerMenu>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool Archived { get; set; }

        public virtual ICollection<CustomerMenu> CustomerMenus { get; set; }
    }
}
