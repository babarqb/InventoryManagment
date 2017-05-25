using System.Collections.Generic;
using InventoryManagment.Models.Domains;

namespace InventoryManagment.DataTypes.Repositories
{
    public interface IAccessoryRepository : IRepository<Accessory>
    {
        IEnumerable<Accessory> GetAllAccessory();
    }
}