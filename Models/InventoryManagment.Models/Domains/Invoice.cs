using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryManagment.Models.Domains
{
    public class Invoice
    {
        public int InvoiceId { get; set; }
        [ForeignKey("OrderId")]
        public Order Order { get; set; }
        public int OrderId { get; set; }
        public DateTime? InvoiceDate { get; set; }
    }
}