using System;
using System.Collections.Generic;

namespace Quality.DAL.Entities
{
    public class Organization
    {
        public Organization()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
