using System;
using System.Collections.Generic;

namespace Quality.DAL.Entities
{
    public class Employee
    {
        public Employee()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
