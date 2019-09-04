using System;
using System.Collections.Generic;

namespace QualityControl.Entities
{
    public partial class Employees
    {
        public Employees()
        {
            Orders = new HashSet<Orders>();
        }

        public int Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public int IdPosition { get; set; }

        public Positions IdPositionNavigation { get; set; }
        public ICollection<Orders> Orders { get; set; }
    }
}
