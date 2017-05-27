using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryManagment.Models.Domains
{
    public class OrderLineItem
    {
        private Accessory _accessory;

        [Key]
        public int OrderLineItemId { get; set; }
        public int OrderId { get; set; }
        [ForeignKey("OrderId")]
        public Order Order { get; set; }

        public decimal Price { get; set; }
        public int? AccessoryId { get; set; }
        [ForeignKey("AccessoryId")]
        public virtual Accessory Accessory
        {
            get { return _accessory; }
            set
            {
                _accessory = value;
                if (value == null)
                {
                    AccessoryId = null;
                }
            }
        }

        public int MobileId { get; set; }
        [ForeignKey("MobileId")]
        public Mobile Mobile { get; set; }
        public int Quantity { get; set; }
    }
}