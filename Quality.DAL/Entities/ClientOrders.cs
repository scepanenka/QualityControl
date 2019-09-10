using System;
using System.Collections.Generic;

namespace Quality.DAL.Entities
{
    public partial class ClientOrders
    {
        public Guid Id { get; set; }
        public Guid IdClient { get; set; }
        public Guid IdOrder { get; set; }

        public Client IdClientNavigation { get; set; }
        public Order IdOrderNavigation { get; set; }
    }
}
