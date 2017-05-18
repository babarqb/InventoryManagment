using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryManagment.Models.Domains
{
    public class PurchaseBill
    {
        [Key]
        public int BillId { get; set; }
        [ForeignKey("PurchaseOrderId")]
        public PurchaseOrder PurchaseOrder { get; set; }
        public int PurchaseOrderId { get; set; }
        public DateTime? BillDate { get; set; }
    }
}