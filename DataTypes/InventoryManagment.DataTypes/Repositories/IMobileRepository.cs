using System.Collections.Generic;
using InventoryManagment.Models.Domains;

namespace InventoryManagment.DataTypes.Repositories
{
    public interface IMobileRepository : IRepository<Mobile>
    {
        void AddMobile(Mobile mobile);
        void UpdateEditMobile(int id);
        IEnumerable<Mobile> GetAllMobiles();
    }
}