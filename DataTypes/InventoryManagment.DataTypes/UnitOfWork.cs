using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagment.DataTypes.Repositories;

namespace InventoryManagment.DataTypes
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            Mobiles = new MobileRepository(_context);
            Accessories = new AccessoryRepository(_context);
            Brands = new BrandRepository(_context);
            Vendors = new VendorRepository(_context);
            Orders = new OrderRepository(_context);
            OrderLineItems = new OrderLineItemRepository(_context);
            Invoices = new InvoiceRepository(_context);
            InvoiceLineItems = new InvoiceLineItemRepository(_context);
            Categories = new CategoryRepository(_context);
            Customers = new CustomerRepository(_context);
            PurchaseOrders = new PurchaseOrderRepository(_context);
            PurchaseLineItems = new PurchaseLineItemRepository(_context);

        }

        public IPurchaseLineItemRepository PurchaseLineItems { get; set; }
        public IPurchaseOrderRepository PurchaseOrders { get; set; }
        public ICategorypository Categories { get; }
        public IMobileRepository Mobiles { get; set; }
        public IAccessoryRepository Accessories { get; }
        public IBrandRepository Brands { get; }
        public IVendorRepository Vendors { get; }
        public IOrderRepository Orders { get; }
        public IOrderLineItemRepository OrderLineItems { get; }
        public IInvoiceRepository Invoices { get; }
        public IInvoiceLineItemRepository InvoiceLineItems { get; }
        public ICustomerRepository Customers { get; }



        public int Complete()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }

    }
}
