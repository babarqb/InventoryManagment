using System.Collections.Generic;
using InventoryManagment.Models.Domains;

namespace InventoryManagment.DataTypes.Repositories
{
    public interface IPurchaseLineItemRepository : IRepository<PurchaseLineItem>
    {
        IEnumerable<PurchaseLineItem> GetAllItems();
    }
}