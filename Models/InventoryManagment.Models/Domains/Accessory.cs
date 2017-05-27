using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryManagment.Models.Domains
{
    public class Accessory
    {
        [Key]
        public int AccessoryId { get; set; }
        [ForeignKey("AccessoryTypeId")]
        public AccessoryType AccessoryType { get; set; }
        public int AccessoryTypeId { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal RetailUnitPrice { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

        public int CategoryId { get; set; }
        [ForeignKey("BrandId")]
        public Brand Brand { get; set; }
        public int BrandId { get; set; }
        public int StockSize { get; set; }
        public string AccessoryCode { get; set; }
        [ForeignKey("VendorId")]
        public Vendor Vendor { get; set; }
        public int VendorId { get; set; }
        public string AccessoryModel { get; set; }

    }
}