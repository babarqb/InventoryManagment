using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagment.Models.Domains
{
    public class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
        }
        [Key]
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string MobileNo { get; set; }
        public string Address { get; set; }
        public string CustomerNic { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
