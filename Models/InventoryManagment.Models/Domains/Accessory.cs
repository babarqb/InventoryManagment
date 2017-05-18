using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryManagment.Models.Domains
{
    public class Accessory
    {
        [Key]
        public int AccessoryId { get; set; }
        public string AccessoryName { get; set; }
        public decimal UnitPrice { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

        public int CategoryId { get; set; }
        [ForeignKey("BrandId")]
        public Brand Brand { get; set; }
        public int BrandId { get; set; }
        public int StockSize { get; set; }
        public string AccessoryDiscripition { get; set; }

    }
}