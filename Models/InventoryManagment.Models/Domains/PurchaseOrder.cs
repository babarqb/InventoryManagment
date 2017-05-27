using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryManagment.Models.Domains
{
    public class PurchaseOrder
    {
        public PurchaseOrder()
        {
            Mobiles = new HashSet<Mobile>();
            Accessories = new HashSet<Accessory>();
            PurchaseLineItems = new HashSet<PurchaseLineItem>();
        }
        [Key]
        public int PurchaseOrderId { get; set; }
        [ForeignKey("VendorId")]
        public Vendor Vendor { get; set; }
        public int VendorId { get; set; }
        public decimal AmountPay { get; set; }
        public DateTime? PurchaseOrderDate { get; set; }
        public string BillNo { get; set; }
        public ICollection<Mobile> Mobiles { get; set; }
        public ICollection<Accessory> Accessories { get; set; }
        public ICollection<PurchaseLineItem> PurchaseLineItems { get; set; }
    }
}