using System;
using InventoryManagment.Models.Domains;

namespace InventoryManagment.DataTypes.Repositories
{
    public class VendorRepository : Repository<Vendor>, IVendorRepository
    {
        public VendorRepository(AppDbContext context) : base(context)
        {

        }
    }
}