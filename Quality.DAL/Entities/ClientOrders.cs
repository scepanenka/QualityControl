using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Quality.DAL.Entities
{
    public partial class ClientOrders
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        [ForeignKey("Client")]
        public Guid IdClient { get; set; }
        [ForeignKey("Order")]
        public Guid IdOrder { get; set; }

        public Client Client { get; set; }
        public Order Order { get; set; }
    }
}
