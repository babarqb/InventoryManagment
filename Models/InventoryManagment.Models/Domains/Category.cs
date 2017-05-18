using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagment.Models.Domains
{
    public class Category
    {
        public Category()
        {
            Mobiles = new HashSet<Mobile>();
            Accessories = new HashSet<Accessory>();
        }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public ICollection<Mobile> Mobiles { get; set; }
        public ICollection<Accessory> Accessories { get; set; }
    }
}
