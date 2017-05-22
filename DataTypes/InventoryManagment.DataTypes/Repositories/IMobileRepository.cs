using InventoryManagment.Models.Domains;

namespace InventoryManagment.DataTypes.Repositories
{
    public interface IMobileRepository : IRepository<Mobile>
    {
        void AddMobile(Mobile mobile);
    }
}