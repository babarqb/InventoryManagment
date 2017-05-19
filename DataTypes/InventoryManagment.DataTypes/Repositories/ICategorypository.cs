using InventoryManagment.Models.Domains;

namespace InventoryManagment.DataTypes.Repositories
{
    public interface ICategorypository : IRepository<Category>
    {
        void UpdateCategory(Category category);
    }
}