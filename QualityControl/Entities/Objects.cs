using System;
using System.Collections.Generic;

namespace QualityControl.Entities
{
    public partial class Objects
    {
        public Objects()
        {
            OrdersObjects = new HashSet<OrdersObjects>();
        }

        public Guid Id { get; set; }
        public int IdObjectType { get; set; }
        public string Address { get; set; }
        public Guid? IdAddress { get; set; }
        public string InvNumber { get; set; }

        public ObjectsTypes IdObjectTypeNavigation { get; set; }
        public ICollection<OrdersObjects> OrdersObjects { get; set; }
    }
}
