using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryManagment.Models.Domains
{
    public class OrderLineItem
    {
        [Key]
        public int OrderLineItemId { get; set; }
        public int OrderId { get; set; }
        [ForeignKey("OrderId")]
        public Order Order { get; set; }

        public decimal Price { get; set; }
        [ForeignKey("AccessoryId")]
        public Accessory Accessory { get; set; }

        public int AccessoryId { get; set; }
        public int MobileId { get; set; }
        [ForeignKey("MobileId")]
        public Mobile Mobile { get; set; }
        public int Quantity { get; set; }
    }
}