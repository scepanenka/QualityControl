using System;
using System.Collections.Generic;

namespace QualityControl.Entities
{
    public partial class OrdersObjects
    {
        public Guid Id { get; set; }
        public Guid? IdOrder { get; set; }
        public Guid? IdObject { get; set; }

        public Objects IdObjectNavigation { get; set; }
        public Orders IdOrderNavigation { get; set; }
    }
}
