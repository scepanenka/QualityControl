using System;
using System.Collections.Generic;

namespace QualityControl.Entities
{
    public partial class Positions
    {
        public Positions()
        {
            Employees = new HashSet<Employees>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Employees> Employees { get; set; }
    }
}
