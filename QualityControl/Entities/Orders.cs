using System;
using System.Collections.Generic;

namespace QualityControl.Entities
{
    public partial class Orders
    {
        public Orders()
        {
            ClientOrders = new HashSet<ClientOrders>();
            OrdersObjects = new HashSet<OrdersObjects>();
            OrdersQuality = new HashSet<OrdersQuality>();
        }

        public Guid Id { get; set; }
        public int IdOrganization { get; set; }
        public int? IdEmployee { get; set; }
        public DateTime DateReceipt { get; set; }
        public DateTime DateExecution { get; set; }
        public string Number { get; set; }

        public Employees IdEmployeeNavigation { get; set; }
        public Organizations IdOrganizationNavigation { get; set; }
        public ICollection<ClientOrders> ClientOrders { get; set; }
        public ICollection<OrdersObjects> OrdersObjects { get; set; }
        public ICollection<OrdersQuality> OrdersQuality { get; set; }
    }
}
