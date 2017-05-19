using InventoryManagment.Models.Domains;

namespace InventoryManagment.DataTypes.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategorypository
    {
        public AppDbContext AppDbContext => Context as AppDbContext;
        public CategoryRepository(AppDbContext context) : base(context)
        {

        }

        public void UpdateCategory(Category category)
        {
            AppDbContext.Categories.Update(category);
        }
    }
}