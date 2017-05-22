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
            Brands = new BrandRepository(context);
            Vendors = new VendorRepository(context);
            Orders = new OrderRepository(context);
            OrderLineItems = new OrderLineItemRepository(context);
            Invoices = new InvoiceRepository(context);
            InvoiceLineItems = new InvoiceLineItemRepository(context);
            Categories = new CategoryRepository(_context);
            Customers = new CustomerRepository(context);

        }
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
