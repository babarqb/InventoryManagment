using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryManagment.Models.Domains
{
    public class Order
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }
        //e.g pending cancelled paid
        public string OrderStatus { get; set; }

        public decimal BalanceAmount { get; set; }
        //public int VendorId { get; set; }
        //[ForeignKey("VendorId")]
        //public Vendor Vendor { get; set; }
        //public int MobileId { get; set; }
        //[ForeignKey("MobileId")]
        //public Mobile Mobile { get; set; }
        //[ForeignKey("AccessoryId")]
        //public int AccessoryId { get; set; }
    }
}