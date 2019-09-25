using System;
using System.Collections.Generic;

namespace QualityControl.Entities
{
    public partial class OrdersQuality
    {
        public Guid Id { get; set; }
        public Guid IdOrder { get; set; }
        public int IdVerifier { get; set; }
        public DateTime Date { get; set; }
        public string Result { get; set; }

        public Orders IdOrderNavigation { get; set; }
        public Employees IdVerifierNavigation { get; set; }
    }
}
