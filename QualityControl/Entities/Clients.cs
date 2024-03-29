﻿using System;
using System.Collections.Generic;

namespace QualityControl.Entities
{
    public partial class Clients
    {
        public Clients()
        {
            ClientOrders = new HashSet<ClientOrders>();
        }

        public Guid Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public string Address { get; set; }
        public string PersonalNumber { get; set; }
        public string PhoneNumber { get; set; }
        public int? TypeClient { get; set; }
        public string Unn { get; set; }
        public DateTime? BothDate { get; set; }
        public string Information { get; set; }

        public ICollection<ClientOrders> ClientOrders { get; set; }
    }
}
