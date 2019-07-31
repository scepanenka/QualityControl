using System;
using System.Collections.Generic;

namespace Quality.DAL.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public int IdOrganization { get; set; }
        public int IdEmployer { get; set; }
        public string Client { get; set; }

        public virtual Employer Employer { get; set; }
        public virtual Organization Organization { get; set; }
    }
}
