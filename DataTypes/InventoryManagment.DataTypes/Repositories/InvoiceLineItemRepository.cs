using InventoryManagment.Models.Domains;

namespace InventoryManagment.DataTypes.Repositories
{
    public class InvoiceLineItemRepository : Repository<InvoiceLineItem>, IInvoiceLineItemRepository
    {
        public InvoiceLineItemRepository(AppDbContext context) : base(context)
        {

        }
    }
}