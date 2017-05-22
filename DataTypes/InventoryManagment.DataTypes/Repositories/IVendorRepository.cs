using System.Collections.Generic;
using InventoryManagment.Models.Domains;

namespace InventoryManagment.DataTypes.Repositories
{
    public interface IVendorRepository : IRepository<Vendor>
    {
        IEnumerable<Vendor> GetAllVendor();
    }
}