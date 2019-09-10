using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Quality.DAL.Entities
{
    public class Organization
    {
        public Organization()
        {
            Orders = new HashSet<Order>();
        }

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

       public ICollection<Order> Orders { get; set; }
    }
}
