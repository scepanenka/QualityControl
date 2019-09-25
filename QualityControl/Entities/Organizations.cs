using System;
using System.Collections.Generic;

namespace QualityControl.Entities
{
    public partial class Organizations
    {
        public Organizations()
        {
            Orders = new HashSet<Orders>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Orders> Orders { get; set; }
    }
}
