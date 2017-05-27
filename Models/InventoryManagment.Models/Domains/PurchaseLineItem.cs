using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryManagment.Models.Domains
{
    public class PurchaseLineItem
    {
        private Mobile _mobile;

        [Key]
        public int PurchaseLineItemId { get; set; }
        public int PurchaseOrderId { get; set; }
        [ForeignKey("PurchaseOrderId")]
        public PurchaseOrder PurchaseOrder { get; set; }

        //public decimal Price { get; set; }
        [ForeignKey("AccessoryId")]
        public Accessory Accessory { get; set; }

        public int AccessoryId { get; set; }
        public int? MobileId { get; set; }

        [ForeignKey("MobileId")]
        public Mobile Mobile
        {
            get { return _mobile; }
            set
            {
                _mobile = value;
                if (value == null)
                {
                    MobileId = null;
                }
            }
        }

        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal RetailPrice { get; set; }
        public decimal TotalPrice { get; set; }

    }
}