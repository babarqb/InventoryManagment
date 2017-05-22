using System;
using System.Collections.Generic;
using System.Linq;
using InventoryManagment.Models.Domains;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagment.DataTypes.Repositories
{
    public class VendorRepository : Repository<Vendor>, IVendorRepository
    {
        public AppDbContext AppDbContext => Context as AppDbContext;
        public VendorRepository(AppDbContext context) : base(context)
        {

        }

        public IEnumerable<Vendor> GetAllVendor()
        {
            return AppDbContext.Vendors.Include(v => v.Mobiles).Include(d => d.Accessories).ToList();
        }
    }
}