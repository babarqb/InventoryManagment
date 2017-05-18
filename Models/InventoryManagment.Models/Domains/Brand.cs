using System.Collections;
using System.Collections.Generic;

namespace InventoryManagment.Models.Domains
{
    public class Brand
    {
        public Brand()
        {
            Mobiles = new HashSet<Mobile>();
            Accessories = new HashSet<Accessory>();
        }
        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public ICollection<Mobile> Mobiles { get; set; }
        public ICollection<Accessory> Accessories { get; set; }

    }
}