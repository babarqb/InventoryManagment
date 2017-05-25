using InventoryManagment.Models.Domains;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagment.DataTypes.Repositories
{
    public class PurchaseOrderRepository : Repository<PurchaseOrder>, IPurchaseOrderRepository

    {
        public AppDbContext AppDbContext => Context as AppDbContext;
        public PurchaseOrderRepository(DbContext context) : base(context)
        {


        }
    }
}