using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryManagment.Models.Domains
{
    public class PurchaseOrder
    {
        public int PurchaseOrderId { get; set; }
        [ForeignKey("VendorId")]
        public Vendor Vendor { get; set; }
        public int VendorId { get; set; }
    }
}