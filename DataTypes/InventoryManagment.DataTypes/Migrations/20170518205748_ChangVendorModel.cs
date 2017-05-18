using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InventoryManagment.DataTypes.Migrations
{
    public partial class ChangVendorModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vendors_Vendors_VendorId1",
                table: "Vendors");

            migrationBuilder.DropIndex(
                name: "IX_Vendors_VendorId1",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "VendorId1",
                table: "Vendors");

            migrationBuilder.AddColumn<decimal>(
                name: "VendorBalance",
                table: "Vendors",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VendorBalance",
                table: "Vendors");

            migrationBuilder.AddColumn<int>(
                name: "VendorId1",
                table: "Vendors",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vendors_VendorId1",
                table: "Vendors",
                column: "VendorId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Vendors_Vendors_VendorId1",
                table: "Vendors",
                column: "VendorId1",
                principalTable: "Vendors",
                principalColumn: "VendorId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
