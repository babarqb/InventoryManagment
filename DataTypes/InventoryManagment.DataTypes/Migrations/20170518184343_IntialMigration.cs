using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InventoryManagment.DataTypes.Migrations
{
    public partial class IntialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    BrandId = table.Column<int>(nullable: false)
                        .Annotation("SqlCe:ValueGeneration", "True"),
                    BrandName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.BrandId);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlCe:ValueGeneration", "True"),
                    CategoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(nullable: false)
                        .Annotation("SqlCe:ValueGeneration", "True"),
                    Address = table.Column<string>(nullable: true),
                    CustomerName = table.Column<string>(nullable: true),
                    CustomerNic = table.Column<string>(nullable: true),
                    MobileNo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Vendors",
                columns: table => new
                {
                    VendorId = table.Column<int>(nullable: false)
                        .Annotation("SqlCe:ValueGeneration", "True"),
                    City = table.Column<string>(nullable: true),
                    Contact = table.Column<string>(nullable: true),
                    VendorId1 = table.Column<int>(nullable: true),
                    VendorName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendors", x => x.VendorId);
                    table.ForeignKey(
                        name: "FK_Vendors_Vendors_VendorId1",
                        column: x => x.VendorId1,
                        principalTable: "Vendors",
                        principalColumn: "VendorId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(nullable: false)
                        .Annotation("SqlCe:ValueGeneration", "True"),
                    BalanceAmount = table.Column<decimal>(nullable: false),
                    CustomerId = table.Column<int>(nullable: false),
                    OrderStatus = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Accessories",
                columns: table => new
                {
                    AccessoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlCe:ValueGeneration", "True"),
                    AccessoryDiscripition = table.Column<string>(nullable: true),
                    AccessoryName = table.Column<string>(nullable: true),
                    BrandId = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false),
                    StockSize = table.Column<int>(nullable: false),
                    UnitPrice = table.Column<decimal>(nullable: false),
                    VendorId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accessories", x => x.AccessoryId);
                    table.ForeignKey(
                        name: "FK_Accessories_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "BrandId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Accessories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Accessories_Vendors_VendorId",
                        column: x => x.VendorId,
                        principalTable: "Vendors",
                        principalColumn: "VendorId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Mobiles",
                columns: table => new
                {
                    MobileId = table.Column<int>(nullable: false)
                        .Annotation("SqlCe:ValueGeneration", "True"),
                    Battary = table.Column<string>(nullable: true),
                    BrandId = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false),
                    Condition = table.Column<string>(nullable: true),
                    Cpu = table.Column<string>(nullable: true),
                    Display = table.Column<string>(nullable: true),
                    FrontCamera = table.Column<string>(nullable: true),
                    Imei1 = table.Column<string>(nullable: true),
                    Imei2 = table.Column<string>(nullable: true),
                    MobileModel = table.Column<string>(nullable: true),
                    MobilePrice = table.Column<decimal>(nullable: false),
                    Os = table.Column<string>(nullable: true),
                    Ram = table.Column<string>(nullable: true),
                    RearCamera = table.Column<string>(nullable: true),
                    Rom = table.Column<string>(nullable: true),
                    StockSize = table.Column<int>(nullable: false),
                    Type = table.Column<string>(nullable: true),
                    VendorId = table.Column<int>(nullable: false),
                    WarrantyVoid = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mobiles", x => x.MobileId);
                    table.ForeignKey(
                        name: "FK_Mobiles_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "BrandId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Mobiles_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Mobiles_Vendors_VendorId",
                        column: x => x.VendorId,
                        principalTable: "Vendors",
                        principalColumn: "VendorId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseOrders",
                columns: table => new
                {
                    PurchaseOrderId = table.Column<int>(nullable: false)
                        .Annotation("SqlCe:ValueGeneration", "True"),
                    VendorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseOrders", x => x.PurchaseOrderId);
                    table.ForeignKey(
                        name: "FK_PurchaseOrders_Vendors_VendorId",
                        column: x => x.VendorId,
                        principalTable: "Vendors",
                        principalColumn: "VendorId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    InvoiceId = table.Column<int>(nullable: false)
                        .Annotation("SqlCe:ValueGeneration", "True"),
                    InvoiceDate = table.Column<DateTime>(nullable: true),
                    OrderId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.InvoiceId);
                    table.ForeignKey(
                        name: "FK_Invoices_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderLineItems",
                columns: table => new
                {
                    OrderLineItemId = table.Column<int>(nullable: false)
                        .Annotation("SqlCe:ValueGeneration", "True"),
                    AccessoryId = table.Column<int>(nullable: false),
                    MobileId = table.Column<int>(nullable: false),
                    OrderId = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderLineItems", x => x.OrderLineItemId);
                    table.ForeignKey(
                        name: "FK_OrderLineItems_Accessories_AccessoryId",
                        column: x => x.AccessoryId,
                        principalTable: "Accessories",
                        principalColumn: "AccessoryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderLineItems_Mobiles_MobileId",
                        column: x => x.MobileId,
                        principalTable: "Mobiles",
                        principalColumn: "MobileId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderLineItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseBills",
                columns: table => new
                {
                    BillId = table.Column<int>(nullable: false)
                        .Annotation("SqlCe:ValueGeneration", "True"),
                    BillDate = table.Column<DateTime>(nullable: true),
                    PurchaseOrderId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseBills", x => x.BillId);
                    table.ForeignKey(
                        name: "FK_PurchaseBills_PurchaseOrders_PurchaseOrderId",
                        column: x => x.PurchaseOrderId,
                        principalTable: "PurchaseOrders",
                        principalColumn: "PurchaseOrderId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseLineItems",
                columns: table => new
                {
                    PurchaseLineItemId = table.Column<int>(nullable: false)
                        .Annotation("SqlCe:ValueGeneration", "True"),
                    AccessoryId = table.Column<int>(nullable: false),
                    MobileId = table.Column<int>(nullable: false),
                    PurchaseOrderId = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseLineItems", x => x.PurchaseLineItemId);
                    table.ForeignKey(
                        name: "FK_PurchaseLineItems_Accessories_AccessoryId",
                        column: x => x.AccessoryId,
                        principalTable: "Accessories",
                        principalColumn: "AccessoryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseLineItems_Mobiles_MobileId",
                        column: x => x.MobileId,
                        principalTable: "Mobiles",
                        principalColumn: "MobileId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseLineItems_PurchaseOrders_PurchaseOrderId",
                        column: x => x.PurchaseOrderId,
                        principalTable: "PurchaseOrders",
                        principalColumn: "PurchaseOrderId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceLineItems",
                columns: table => new
                {
                    InvoiceLineItemId = table.Column<int>(nullable: false)
                        .Annotation("SqlCe:ValueGeneration", "True"),
                    AccessoryId = table.Column<int>(nullable: false),
                    InvoiceId = table.Column<int>(nullable: false),
                    LineItemPrice = table.Column<decimal>(nullable: false),
                    MobileId = table.Column<int>(nullable: false),
                    OrderLineItemId = table.Column<int>(nullable: false),
                    Quntity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceLineItems", x => x.InvoiceLineItemId);
                    table.ForeignKey(
                        name: "FK_InvoiceLineItems_Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoices",
                        principalColumn: "InvoiceId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InvoiceLineItems_Mobiles_MobileId",
                        column: x => x.MobileId,
                        principalTable: "Mobiles",
                        principalColumn: "MobileId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InvoiceLineItems_OrderLineItems_OrderLineItemId",
                        column: x => x.OrderLineItemId,
                        principalTable: "OrderLineItems",
                        principalColumn: "OrderLineItemId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accessories_BrandId",
                table: "Accessories",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Accessories_CategoryId",
                table: "Accessories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Accessories_VendorId",
                table: "Accessories",
                column: "VendorId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_OrderId",
                table: "Invoices",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceLineItems_InvoiceId",
                table: "InvoiceLineItems",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceLineItems_MobileId",
                table: "InvoiceLineItems",
                column: "MobileId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceLineItems_OrderLineItemId",
                table: "InvoiceLineItems",
                column: "OrderLineItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Mobiles_BrandId",
                table: "Mobiles",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Mobiles_CategoryId",
                table: "Mobiles",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Mobiles_VendorId",
                table: "Mobiles",
                column: "VendorId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderLineItems_AccessoryId",
                table: "OrderLineItems",
                column: "AccessoryId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderLineItems_MobileId",
                table: "OrderLineItems",
                column: "MobileId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderLineItems_OrderId",
                table: "OrderLineItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseBills_PurchaseOrderId",
                table: "PurchaseBills",
                column: "PurchaseOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseLineItems_AccessoryId",
                table: "PurchaseLineItems",
                column: "AccessoryId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseLineItems_MobileId",
                table: "PurchaseLineItems",
                column: "MobileId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseLineItems_PurchaseOrderId",
                table: "PurchaseLineItems",
                column: "PurchaseOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrders_VendorId",
                table: "PurchaseOrders",
                column: "VendorId");

            migrationBuilder.CreateIndex(
                name: "IX_Vendors_VendorId1",
                table: "Vendors",
                column: "VendorId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InvoiceLineItems");

            migrationBuilder.DropTable(
                name: "PurchaseBills");

            migrationBuilder.DropTable(
                name: "PurchaseLineItems");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "OrderLineItems");

            migrationBuilder.DropTable(
                name: "PurchaseOrders");

            migrationBuilder.DropTable(
                name: "Accessories");

            migrationBuilder.DropTable(
                name: "Mobiles");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Vendors");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
