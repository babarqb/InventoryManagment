using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace InventoryManagment.Models.Domains
{
    public class Mobile
    {
        public int MobileId { get; set; }
        public string Imei1 { get; set; }
        public string Imei2 { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
        public int CategoryId { get; set; }

        [ForeignKey("BrandId")]
        public Brand Brand { get; set; }
        public int BrandId { get; set; }
        [ForeignKey("VendorId")]
        public Vendor Vendor { get; set; }
        public int VendorId { get; set; }
        public string MobileModel { get; set; }
        public DateTime? WarrantyVoid { get; set; }

        public string Condition { get; set; }
        public string Type { get; set; }
        public string Ram { get; set; }
        public string Rom { get; set; }
        public string Battary { get; set; }
        public string Cpu { get; set; }
        [Required]
        public decimal MobilePrice { get; set; }
        public decimal MobileRetailPrice { get; set; }
        public string Display { get; set; }
        [Required]
        public int StockSize { get; set; }

        public string Os { get; set; }
        public string RearCamera { get; set; }
        public string FrontCamera { get; set; }

    }
}