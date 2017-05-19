using System;
using InventoryManagment.Models.Domains;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagment.DataTypes.Repositories
{
    public class BrandRepository : Repository<Brand>, IBrandRepository
    {
        public DbContext Context => Context as AppDbContext;

        public BrandRepository(DbContext context) : base(context)
        {

        }
    }
}