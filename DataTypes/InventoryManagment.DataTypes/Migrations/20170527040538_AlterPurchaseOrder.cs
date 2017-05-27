using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InventoryManagment.DataTypes.Migrations
{
    public partial class AlterPurchaseOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PurchaseOrderId",
                table: "Mobiles",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PurchaseOrderId",
                table: "Accessories",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Mobiles_PurchaseOrderId",
                table: "Mobiles",
                column: "PurchaseOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Accessories_PurchaseOrderId",
                table: "Accessories",
                column: "PurchaseOrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Accessories_PurchaseOrders_PurchaseOrderId",
                table: "Accessories",
                column: "PurchaseOrderId",
                principalTable: "PurchaseOrders",
                principalColumn: "PurchaseOrderId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Mobiles_PurchaseOrders_PurchaseOrderId",
                table: "Mobiles",
                column: "PurchaseOrderId",
                principalTable: "PurchaseOrders",
                principalColumn: "PurchaseOrderId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accessories_PurchaseOrders_PurchaseOrderId",
                table: "Accessories");

            migrationBuilder.DropForeignKey(
                name: "FK_Mobiles_PurchaseOrders_PurchaseOrderId",
                table: "Mobiles");

            migrationBuilder.DropIndex(
                name: "IX_Mobiles_PurchaseOrderId",
                table: "Mobiles");

            migrationBuilder.DropIndex(
                name: "IX_Accessories_PurchaseOrderId",
                table: "Accessories");

            migrationBuilder.DropColumn(
                name: "PurchaseOrderId",
                table: "Mobiles");

            migrationBuilder.DropColumn(
                name: "PurchaseOrderId",
                table: "Accessories");
        }
    }
}
