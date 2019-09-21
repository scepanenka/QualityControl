using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Quality.DAL.Entities;

namespace QualityControl.ViewModels
{
    public class OrderViewModel
    {
        public Guid Id { get; set; }
        public string Number { get; set; }
        public string Employee { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm:ss}")]
        public DateTime DateReceipt { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime DateExecution { get; set; }
        public string Organization { get; set; }
    }
}
