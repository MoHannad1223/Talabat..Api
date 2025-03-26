using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Talabat.Repository.Data.Migrations
{
    /// <inheritdoc />
    public partial class Secondcreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_products_productBrands_ProductBrandId",
                table: "products");

            migrationBuilder.DropForeignKey(
                name: "FK_products_productTypes_ProductTypeId",
                table: "products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_productTypes",
                table: "productTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_products",
                table: "products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_productBrands",
                table: "productBrands");

            migrationBuilder.RenameTable(
                name: "productTypes",
                newName: "ProductTypes");

            migrationBuilder.RenameTable(
                name: "products",
                newName: "Products");

            migrationBuilder.RenameTable(
                name: "productBrands",
                newName: "ProductBrands");

            migrationBuilder.RenameIndex(
                name: "IX_products_ProductTypeId",
                table: "Products",
                newName: "IX_Products_ProductTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_products_ProductBrandId",
                table: "Products",
                newName: "IX_Products_ProductBrandId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductTypes",
                table: "ProductTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductBrands",
                table: "ProductBrands",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductBrands_ProductBrandId",
                table: "Products",
                column: "ProductBrandId",
                principalTable: "ProductBrands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductTypes_ProductTypeId",
                table: "Products",
                column: "ProductTypeId",
                principalTable: "ProductTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductBrands_ProductBrandId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductTypes_ProductTypeId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductTypes",
                table: "ProductTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductBrands",
                table: "ProductBrands");

            migrationBuilder.RenameTable(
                name: "ProductTypes",
                newName: "productTypes");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "products");

            migrationBuilder.RenameTable(
                name: "ProductBrands",
                newName: "productBrands");

            migrationBuilder.RenameIndex(
                name: "IX_Products_ProductTypeId",
                table: "products",
                newName: "IX_products_ProductTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_ProductBrandId",
                table: "products",
                newName: "IX_products_ProductBrandId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_productTypes",
                table: "productTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_products",
                table: "products",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_productBrands",
                table: "productBrands",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_products_productBrands_ProductBrandId",
                table: "products",
                column: "ProductBrandId",
                principalTable: "productBrands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_products_productTypes_ProductTypeId",
                table: "products",
                column: "ProductTypeId",
                principalTable: "productTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
