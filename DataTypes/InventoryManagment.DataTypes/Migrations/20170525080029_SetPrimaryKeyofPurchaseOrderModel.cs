using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InventoryManagment.DataTypes.Migrations
{
    public partial class SetPrimaryKeyofPurchaseOrderModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "PurchaseOrderDate",
                table: "PurchaseOrders",
                nullable: true,
                oldClrType: typeof(DateTime));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "PurchaseOrderDate",
                table: "PurchaseOrders",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);
        }
    }
}
