using System;
using System.Collections.Generic;

namespace QualityControl.Entities
{
    public partial class ClientOrders
    {
        public Guid Id { get; set; }
        public Guid IdClient { get; set; }
        public Guid IdOrder { get; set; }

        public Clients IdClientNavigation { get; set; }
        public Orders IdOrderNavigation { get; set; }
    }
}
