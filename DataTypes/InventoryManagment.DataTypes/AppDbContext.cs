
using System.Linq;
using InventoryManagment.Models.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;


namespace InventoryManagment.DataTypes
{
    public class AppDbContext : DbContext
    {
        public virtual DbSet<Mobile> Mobiles { get; set; }
        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<Accessory> Accessories { get; set; }
        public virtual DbSet<Vendor> Vendors { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderLineItem> OrderLineItems { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<PurchaseBill> PurchaseBills { get; set; }
        public virtual DbSet<PurchaseLineItem> PurchaseLineItems { get; set; }
        public virtual DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<InvoiceLineItem> InvoiceLineItems { get; set; }
        public virtual DbSet<AccessoryType> AccessoryTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlCe(@"Data Source=C:/Data/InventoryManagmentDB.sdf");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}