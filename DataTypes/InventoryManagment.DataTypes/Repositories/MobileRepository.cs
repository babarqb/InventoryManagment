using System;
using System.Collections.Generic;
using System.Linq;
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

        public void UpdateEditMobile(int id)
        {
            var mobile = AppDbContext.Mobiles.FirstOrDefault(m => m.MobileId == id);
            if (mobile != null) AppDbContext.Mobiles.Update(mobile);
        }

        public IEnumerable<Mobile> GetAllMobiles()
        {
            return AppDbContext.Mobiles.Where(m => m.MobileModel != "--");
        }
    }
}