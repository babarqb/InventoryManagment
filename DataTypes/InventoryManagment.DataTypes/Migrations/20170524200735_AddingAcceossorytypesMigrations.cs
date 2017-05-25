using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InventoryManagment.DataTypes.Migrations
{
    public partial class AddingAcceossorytypesMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accessories_AccessoryType_AccessoryTypeId",
                table: "Accessories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AccessoryType",
                table: "AccessoryType");

            migrationBuilder.RenameTable(
                name: "AccessoryType",
                newName: "AccessoryTypes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AccessoryTypes",
                table: "AccessoryTypes",
                column: "AccessoryTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Accessories_AccessoryTypes_AccessoryTypeId",
                table: "Accessories",
                column: "AccessoryTypeId",
                principalTable: "AccessoryTypes",
                principalColumn: "AccessoryTypeId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accessories_AccessoryTypes_AccessoryTypeId",
                table: "Accessories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AccessoryTypes",
                table: "AccessoryTypes");

            migrationBuilder.RenameTable(
                name: "AccessoryTypes",
                newName: "AccessoryType");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AccessoryType",
                table: "AccessoryType",
                column: "AccessoryTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Accessories_AccessoryType_AccessoryTypeId",
                table: "Accessories",
                column: "AccessoryTypeId",
                principalTable: "AccessoryType",
                principalColumn: "AccessoryTypeId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
