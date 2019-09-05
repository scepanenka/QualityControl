using System;
using System.Collections.Generic;

namespace Quality.DAL.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public int? IdOrganization { get; set; }
        public int? IdEmployee { get; set; }
        public string Client { get; set; }

        public Employee Employee { get; set; }
        public Organization Organization { get; set; }
    }
}
