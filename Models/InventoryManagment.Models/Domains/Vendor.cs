using System.Collections.Generic;

namespace InventoryManagment.Models.Domains
{
    public class Vendor
    {
        public Vendor()
        {
            Mobiles = new HashSet<Mobile>();
            Accessories = new HashSet<Accessory>();
            
        }
        public int VendorId { get; set; }
        public string VendorName { get; set; }
        public string City { get; set; }
        public string Contact { get; set; }
        public ICollection<Mobile> Mobiles { get; set; }
        public ICollection<Accessory> Accessories { get; set; }
        public decimal VendorBalance { get; set; }
    }
}