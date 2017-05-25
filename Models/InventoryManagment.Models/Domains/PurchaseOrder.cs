using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryManagment.Models.Domains
{
    public class PurchaseOrder
    {
        [Key]
        public int PurchaseOrderId { get; set; }
        [ForeignKey("VendorId")]
        public Vendor Vendor { get; set; }
        public int VendorId { get; set; }
        public decimal AmountPay { get; set; }
        public DateTime? PurchaseOrderDate { get; set; }
        public string BillNo { get; set; }
    }
}