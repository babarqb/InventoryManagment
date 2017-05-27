using System.Collections.Generic;

namespace InventoryManagment.Models.Domains
{
    public class AccessoryType
    {
        public AccessoryType()
        {
            Accessories = new HashSet<Accessory>();
        }
        public int AccessoryTypeId { get; set; }
        public string AccessoryTypeName { get; set; }
        public ICollection<Accessory> Accessories { get; set; }
    }
}