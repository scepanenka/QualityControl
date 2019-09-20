using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QualityControl.ViewModels
{
    public class OrdersListViewModel
    {
        public int IdOrganization { get; set; }
        public int IdEmployee { get; set; }
        public DateTime DateReceipt { get; set; }
        public DateTime DateExecution { get; set; }
        public string Number { get; set; }

    }
}
