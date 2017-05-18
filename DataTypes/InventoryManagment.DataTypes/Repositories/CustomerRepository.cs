using InventoryManagment.Models.Domains;

namespace InventoryManagment.DataTypes.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(AppDbContext context) : base(context)
        {

        }
    }
}