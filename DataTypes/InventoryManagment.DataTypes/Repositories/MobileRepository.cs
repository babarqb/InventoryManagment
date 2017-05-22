using System;
using InventoryManagment.Models.Domains;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagment.DataTypes.Repositories
{
    public class MobileRepository : Repository<Mobile>, IMobileRepository
    {
        public AppDbContext AppDbContext => Context as AppDbContext;
        public MobileRepository(DbContext context) : base(context)
        {

        }

        public void AddMobile(Mobile mobile)
        {

        }
    }
}