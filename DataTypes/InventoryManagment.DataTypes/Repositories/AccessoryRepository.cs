using System;
using System.Collections.Generic;
using InventoryManagment.Models.Domains;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagment.DataTypes.Repositories
{
    public class AccessoryRepository : Repository<Accessory>, IAccessoryRepository
    {
        public AccessoryRepository(DbContext context) : base(context)
        {

        }

        public IEnumerable<Accessory> GetAllAccessory()
        {
            return null;
        }
    }
}