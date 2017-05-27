using System.Collections.Generic;
using System.Linq;
using InventoryManagment.DataTypes.Repositories;
using InventoryManagment.Models.Domains;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagment.DataTypes.Repositories
{
    public class PurchaseLineItemRepository : Repository<PurchaseLineItem>, IPurchaseLineItemRepository
    {
        public AppDbContext AppDbContext => Context as AppDbContext;
        public PurchaseLineItemRepository(DbContext context) : base(context)
        {

        }

        public IEnumerable<PurchaseLineItem> GetAllItems()
        {
            return AppDbContext.PurchaseLineItems.Include("PurchaseOrder");
        }
    }
}