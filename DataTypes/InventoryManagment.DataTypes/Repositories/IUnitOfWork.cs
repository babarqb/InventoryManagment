using System;

namespace InventoryManagment.DataTypes.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IMobileRepository Mobiles { get; set; }
        IAccessoryRepository Accessories { get; }
        IBrandRepository Brands { get; }
        IVendorRepository Vendors { get; }
        IOrderRepository Orders { get; }
        IOrderLineItemRepository OrderLineItems { get; }
        IInvoiceRepository Invoices { get; }
        IInvoiceLineItemRepository InvoiceLineItems { get; }
        ICategorypository Categories { get; }
        int Complete();
    }
}