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
        ICategorypository Categories { get; }
        IInvoiceLineItemRepository InvoiceLineItems { get; }
        IPurchaseLineItemRepository PurchaseLineItems { get; }
        IPurchaseOrderRepository PurchaseOrders { get; }
        int Complete();
    }
}