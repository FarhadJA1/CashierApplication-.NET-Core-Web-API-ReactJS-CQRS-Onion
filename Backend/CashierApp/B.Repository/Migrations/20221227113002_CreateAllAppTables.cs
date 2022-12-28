using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace B.Repository.Migrations
{
    public partial class CreateAllAppTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductProperty_MeasureUnit_MeasureUnitId",
                table: "ProductProperty");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductProperty_Product_ProductId",
                table: "ProductProperty");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductProperty",
                table: "ProductProperty");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Product",
                table: "Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MeasureUnit",
                table: "MeasureUnit");

            migrationBuilder.RenameTable(
                name: "ProductProperty",
                newName: "ProductProperties");

            migrationBuilder.RenameTable(
                name: "Product",
                newName: "Products");

            migrationBuilder.RenameTable(
                name: "MeasureUnit",
                newName: "MeasureUnits");

            migrationBuilder.RenameIndex(
                name: "IX_ProductProperty_MeasureUnitId",
                table: "ProductProperties",
                newName: "IX_ProductProperties_MeasureUnitId");

            migrationBuilder.RenameIndex(
                name: "IX_Product_Barcode",
                table: "Products",
                newName: "IX_Products_Barcode");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductProperties",
                table: "ProductProperties",
                columns: new[] { "ProductId", "MeasureUnitId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MeasureUnits",
                table: "MeasureUnits",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "AppUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ImportInvoices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImportInvoices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReturnInvoices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReturnInvoices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SellingInvoices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SellingInvoices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MeasureId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ImportInvoiceId = table.Column<int>(type: "int", nullable: true),
                    ReturnInvoiceId = table.Column<int>(type: "int", nullable: true),
                    SellingInvoiceId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvoiceDetails_ImportInvoices_ImportInvoiceId",
                        column: x => x.ImportInvoiceId,
                        principalTable: "ImportInvoices",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InvoiceDetails_ReturnInvoices_ReturnInvoiceId",
                        column: x => x.ReturnInvoiceId,
                        principalTable: "ReturnInvoices",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InvoiceDetails_SellingInvoices_SellingInvoiceId",
                        column: x => x.SellingInvoiceId,
                        principalTable: "SellingInvoices",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDetails_ImportInvoiceId",
                table: "InvoiceDetails",
                column: "ImportInvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDetails_ReturnInvoiceId",
                table: "InvoiceDetails",
                column: "ReturnInvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDetails_SellingInvoiceId",
                table: "InvoiceDetails",
                column: "SellingInvoiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductProperties_MeasureUnits_MeasureUnitId",
                table: "ProductProperties",
                column: "MeasureUnitId",
                principalTable: "MeasureUnits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductProperties_Products_ProductId",
                table: "ProductProperties",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductProperties_MeasureUnits_MeasureUnitId",
                table: "ProductProperties");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductProperties_Products_ProductId",
                table: "ProductProperties");

            migrationBuilder.DropTable(
                name: "AppUsers");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "InvoiceDetails");

            migrationBuilder.DropTable(
                name: "ImportInvoices");

            migrationBuilder.DropTable(
                name: "ReturnInvoices");

            migrationBuilder.DropTable(
                name: "SellingInvoices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductProperties",
                table: "ProductProperties");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MeasureUnits",
                table: "MeasureUnits");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "Product");

            migrationBuilder.RenameTable(
                name: "ProductProperties",
                newName: "ProductProperty");

            migrationBuilder.RenameTable(
                name: "MeasureUnits",
                newName: "MeasureUnit");

            migrationBuilder.RenameIndex(
                name: "IX_Products_Barcode",
                table: "Product",
                newName: "IX_Product_Barcode");

            migrationBuilder.RenameIndex(
                name: "IX_ProductProperties_MeasureUnitId",
                table: "ProductProperty",
                newName: "IX_ProductProperty_MeasureUnitId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product",
                table: "Product",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductProperty",
                table: "ProductProperty",
                columns: new[] { "ProductId", "MeasureUnitId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_MeasureUnit",
                table: "MeasureUnit",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductProperty_MeasureUnit_MeasureUnitId",
                table: "ProductProperty",
                column: "MeasureUnitId",
                principalTable: "MeasureUnit",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductProperty_Product_ProductId",
                table: "ProductProperty",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
