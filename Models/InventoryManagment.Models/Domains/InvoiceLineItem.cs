using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagment.Models.Domains
{
    public class InvoiceLineItem
    {
        public int InvoiceLineItemId { get; set; }
        [ForeignKey("InvoiceId")]
        public Invoice Invoice { get; set; }
        public int InvoiceId { get; set; }
        [ForeignKey("OrderLineItemId")]
        public OrderLineItem OrderLineItem { get; set; }
        public int OrderLineItemId { get; set; }
        public int Quntity { get; set; }
        public int MobileId { get; set; }
        [ForeignKey("MobileId")]
        public Mobile Mobile { get; set; }
        [ForeignKey("AccessoryId")]
        public int AccessoryId { get; set; }

        public decimal LineItemPrice { get; set; }
    }
}
