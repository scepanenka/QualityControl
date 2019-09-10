using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Quality.DAL.Entities
{
    public partial class Order
    {
        public Order()
        {
            ClientOrders = new HashSet<ClientOrders>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        [ForeignKey("Organization")]
        public int IdOrganization { get; set; }
        [ForeignKey("Employee")]
        public int IdEmployee { get; set; }
        public DateTime DateReceipt { get; set; }
        public DateTime DateExecution { get; set; }
        public string Number { get; set; }

        public Employee Employee { get; set; }
        public Organization Organization { get; set; }
        public ICollection<ClientOrders> ClientOrders { get; set; }
    }
}