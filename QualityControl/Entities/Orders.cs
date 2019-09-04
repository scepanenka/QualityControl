using System;
using System.Collections.Generic;

namespace QualityControl.Entities
{
    public partial class Orders
    {
        public int Id { get; set; }
        public int IdOrganization { get; set; }
        public int IdEmployee { get; set; }
        public string Client { get; set; }

        public Employees IdEmployeeNavigation { get; set; }
        public Organizations IdOrganizationNavigation { get; set; }
    }
}
