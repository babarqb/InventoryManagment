using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using InventoryManagment.DataTypes;

namespace InventoryManagment.DataTypes.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20170527061933_AlterPurchaseOrder2")]
    partial class AlterPurchaseOrder2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2");

            modelBuilder.Entity("InventoryManagment.Models.Domains.Accessory", b =>
                {
                    b.Property<int>("AccessoryId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AccessoryCode");

                    b.Property<string>("AccessoryModel");

                    b.Property<int>("AccessoryTypeId");

                    b.Property<int>("BrandId");

                    b.Property<int>("CategoryId");

                    b.Property<int?>("PurchaseOrderId");

                    b.Property<decimal>("RetailUnitPrice");

                    b.Property<int>("StockSize");

                    b.Property<decimal>("TotalPrice");

                    b.Property<decimal>("UnitPrice");

                    b.Property<int>("VendorId");

                    b.HasKey("AccessoryId");

                    b.HasIndex("AccessoryTypeId");

                    b.HasIndex("BrandId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("PurchaseOrderId");

                    b.HasIndex("VendorId");

                    b.ToTable("Accessories");
                });

            modelBuilder.Entity("InventoryManagment.Models.Domains.AccessoryType", b =>
                {
                    b.Property<int>("AccessoryTypeId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AccessoryTypeName");

                    b.HasKey("AccessoryTypeId");

                    b.ToTable("AccessoryTypes");
                });

            modelBuilder.Entity("InventoryManagment.Models.Domains.Brand", b =>
                {
                    b.Property<int>("BrandId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BrandName");

                    b.HasKey("BrandId");

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("InventoryManagment.Models.Domains.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CategoryName");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("InventoryManagment.Models.Domains.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("CustomerName");

                    b.Property<string>("CustomerNic");

                    b.Property<string>("MobileNo");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("InventoryManagment.Models.Domains.Invoice", b =>
                {
                    b.Property<int>("InvoiceId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("InvoiceDate");

                    b.Property<int>("OrderId");

                    b.HasKey("InvoiceId");

                    b.HasIndex("OrderId");

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("InventoryManagment.Models.Domains.InvoiceLineItem", b =>
                {
                    b.Property<int>("InvoiceLineItemId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessoryId");

                    b.Property<int>("InvoiceId");

                    b.Property<decimal>("LineItemPrice");

                    b.Property<int>("MobileId");

                    b.Property<int>("OrderLineItemId");

                    b.Property<int>("Quntity");

                    b.HasKey("InvoiceLineItemId");

                    b.HasIndex("InvoiceId");

                    b.HasIndex("MobileId");

                    b.HasIndex("OrderLineItemId");

                    b.ToTable("InvoiceLineItems");
                });

            modelBuilder.Entity("InventoryManagment.Models.Domains.Mobile", b =>
                {
                    b.Property<int>("MobileId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Battary");

                    b.Property<int>("BrandId");

                    b.Property<int>("CategoryId");

                    b.Property<string>("Condition");

                    b.Property<string>("Cpu");

                    b.Property<string>("Display");

                    b.Property<string>("FrontCamera");

                    b.Property<string>("Imei1");

                    b.Property<string>("Imei2");

                    b.Property<string>("MobileModel");

                    b.Property<decimal>("MobilePrice");

                    b.Property<decimal>("MobileRetailPrice");

                    b.Property<string>("Os");

                    b.Property<int?>("PurchaseOrderId");

                    b.Property<string>("Ram");

                    b.Property<string>("RearCamera");

                    b.Property<string>("Rom");

                    b.Property<int>("StockSize");

                    b.Property<string>("Type");

                    b.Property<int>("VendorId");

                    b.Property<DateTime?>("WarrantyVoid");

                    b.HasKey("MobileId");

                    b.HasIndex("BrandId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("PurchaseOrderId");

                    b.HasIndex("VendorId");

                    b.ToTable("Mobiles");
                });

            modelBuilder.Entity("InventoryManagment.Models.Domains.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("BalanceAmount");

                    b.Property<int>("CustomerId");

                    b.Property<string>("OrderStatus");

                    b.HasKey("OrderId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("InventoryManagment.Models.Domains.OrderLineItem", b =>
                {
                    b.Property<int>("OrderLineItemId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AccessoryId");

                    b.Property<int>("MobileId");

                    b.Property<int>("OrderId");

                    b.Property<decimal>("Price");

                    b.Property<int>("Quantity");

                    b.HasKey("OrderLineItemId");

                    b.HasIndex("AccessoryId");

                    b.HasIndex("MobileId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderLineItems");
                });

            modelBuilder.Entity("InventoryManagment.Models.Domains.PurchaseBill", b =>
                {
                    b.Property<int>("BillId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("BillDate");

                    b.Property<int>("PurchaseOrderId");

                    b.HasKey("BillId");

                    b.HasIndex("PurchaseOrderId");

                    b.ToTable("PurchaseBills");
                });

            modelBuilder.Entity("InventoryManagment.Models.Domains.PurchaseLineItem", b =>
                {
                    b.Property<int>("PurchaseLineItemId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessoryId");

                    b.Property<int?>("MobileId");

                    b.Property<int>("PurchaseOrderId");

                    b.Property<int>("Quantity");

                    b.Property<decimal>("RetailPrice");

                    b.Property<decimal>("TotalPrice");

                    b.Property<decimal>("UnitPrice");

                    b.HasKey("PurchaseLineItemId");

                    b.HasIndex("AccessoryId");

                    b.HasIndex("MobileId");

                    b.HasIndex("PurchaseOrderId");

                    b.ToTable("PurchaseLineItems");
                });

            modelBuilder.Entity("InventoryManagment.Models.Domains.PurchaseOrder", b =>
                {
                    b.Property<int>("PurchaseOrderId")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("AmountPay");

                    b.Property<string>("BillNo");

                    b.Property<DateTime?>("PurchaseOrderDate");

                    b.Property<int>("VendorId");

                    b.HasKey("PurchaseOrderId");

                    b.HasIndex("VendorId");

                    b.ToTable("PurchaseOrders");
                });

            modelBuilder.Entity("InventoryManagment.Models.Domains.Vendor", b =>
                {
                    b.Property<int>("VendorId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City");

                    b.Property<string>("Contact");

                    b.Property<decimal>("VendorBalance");

                    b.Property<string>("VendorName");

                    b.HasKey("VendorId");

                    b.ToTable("Vendors");
                });

            modelBuilder.Entity("InventoryManagment.Models.Domains.Accessory", b =>
                {
                    b.HasOne("InventoryManagment.Models.Domains.AccessoryType", "AccessoryType")
                        .WithMany("Accessories")
                        .HasForeignKey("AccessoryTypeId");

                    b.HasOne("InventoryManagment.Models.Domains.Brand", "Brand")
                        .WithMany("Accessories")
                        .HasForeignKey("BrandId");

                    b.HasOne("InventoryManagment.Models.Domains.Category", "Category")
                        .WithMany("Accessories")
                        .HasForeignKey("CategoryId");

                    b.HasOne("InventoryManagment.Models.Domains.PurchaseOrder")
                        .WithMany("Accessories")
                        .HasForeignKey("PurchaseOrderId");

                    b.HasOne("InventoryManagment.Models.Domains.Vendor", "Vendor")
                        .WithMany("Accessories")
                        .HasForeignKey("VendorId");
                });

            modelBuilder.Entity("InventoryManagment.Models.Domains.Invoice", b =>
                {
                    b.HasOne("InventoryManagment.Models.Domains.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderId");
                });

            modelBuilder.Entity("InventoryManagment.Models.Domains.InvoiceLineItem", b =>
                {
                    b.HasOne("InventoryManagment.Models.Domains.Invoice", "Invoice")
                        .WithMany()
                        .HasForeignKey("InvoiceId");

                    b.HasOne("InventoryManagment.Models.Domains.Mobile", "Mobile")
                        .WithMany()
                        .HasForeignKey("MobileId");

                    b.HasOne("InventoryManagment.Models.Domains.OrderLineItem", "OrderLineItem")
                        .WithMany()
                        .HasForeignKey("OrderLineItemId");
                });

            modelBuilder.Entity("InventoryManagment.Models.Domains.Mobile", b =>
                {
                    b.HasOne("InventoryManagment.Models.Domains.Brand", "Brand")
                        .WithMany("Mobiles")
                        .HasForeignKey("BrandId");

                    b.HasOne("InventoryManagment.Models.Domains.Category", "Category")
                        .WithMany("Mobiles")
                        .HasForeignKey("CategoryId");

                    b.HasOne("InventoryManagment.Models.Domains.PurchaseOrder")
                        .WithMany("Mobiles")
                        .HasForeignKey("PurchaseOrderId");

                    b.HasOne("InventoryManagment.Models.Domains.Vendor", "Vendor")
                        .WithMany("Mobiles")
                        .HasForeignKey("VendorId");
                });

            modelBuilder.Entity("InventoryManagment.Models.Domains.Order", b =>
                {
                    b.HasOne("InventoryManagment.Models.Domains.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId");
                });

            modelBuilder.Entity("InventoryManagment.Models.Domains.OrderLineItem", b =>
                {
                    b.HasOne("InventoryManagment.Models.Domains.Accessory", "Accessory")
                        .WithMany()
                        .HasForeignKey("AccessoryId");

                    b.HasOne("InventoryManagment.Models.Domains.Mobile", "Mobile")
                        .WithMany()
                        .HasForeignKey("MobileId");

                    b.HasOne("InventoryManagment.Models.Domains.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderId");
                });

            modelBuilder.Entity("InventoryManagment.Models.Domains.PurchaseBill", b =>
                {
                    b.HasOne("InventoryManagment.Models.Domains.PurchaseOrder", "PurchaseOrder")
                        .WithMany()
                        .HasForeignKey("PurchaseOrderId");
                });

            modelBuilder.Entity("InventoryManagment.Models.Domains.PurchaseLineItem", b =>
                {
                    b.HasOne("InventoryManagment.Models.Domains.Accessory", "Accessory")
                        .WithMany()
                        .HasForeignKey("AccessoryId");

                    b.HasOne("InventoryManagment.Models.Domains.Mobile", "Mobile")
                        .WithMany()
                        .HasForeignKey("MobileId");

                    b.HasOne("InventoryManagment.Models.Domains.PurchaseOrder", "PurchaseOrder")
                        .WithMany("PurchaseLineItems")
                        .HasForeignKey("PurchaseOrderId");
                });

            modelBuilder.Entity("InventoryManagment.Models.Domains.PurchaseOrder", b =>
                {
                    b.HasOne("InventoryManagment.Models.Domains.Vendor", "Vendor")
                        .WithMany()
                        .HasForeignKey("VendorId");
                });
        }
    }
}
