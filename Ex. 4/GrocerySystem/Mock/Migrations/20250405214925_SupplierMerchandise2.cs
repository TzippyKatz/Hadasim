using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mock.Migrations
{
    public partial class SupplierMerchandise2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_supplierMerchandises_merchs_MarchandiseId",
                table: "supplierMerchandises");

            migrationBuilder.DropForeignKey(
                name: "FK_supplierMerchandises_suppliers_SuppplierId",
                table: "supplierMerchandises");

            migrationBuilder.DropIndex(
                name: "IX_supplierMerchandises_MarchandiseId",
                table: "supplierMerchandises");

            migrationBuilder.DropIndex(
                name: "IX_supplierMerchandises_SuppplierId",
                table: "supplierMerchandises");

            migrationBuilder.AddColumn<int>(
                name: "MerchandiseId",
                table: "supplierMerchandises",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SupplierId",
                table: "supplierMerchandises",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_supplierMerchandises_MerchandiseId",
                table: "supplierMerchandises",
                column: "MerchandiseId");

            migrationBuilder.CreateIndex(
                name: "IX_supplierMerchandises_SupplierId",
                table: "supplierMerchandises",
                column: "SupplierId");

            migrationBuilder.AddForeignKey(
                name: "FK_supplierMerchandises_merchs_MerchandiseId",
                table: "supplierMerchandises",
                column: "MerchandiseId",
                principalTable: "merchs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_supplierMerchandises_suppliers_SupplierId",
                table: "supplierMerchandises",
                column: "SupplierId",
                principalTable: "suppliers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_supplierMerchandises_merchs_MerchandiseId",
                table: "supplierMerchandises");

            migrationBuilder.DropForeignKey(
                name: "FK_supplierMerchandises_suppliers_SupplierId",
                table: "supplierMerchandises");

            migrationBuilder.DropIndex(
                name: "IX_supplierMerchandises_MerchandiseId",
                table: "supplierMerchandises");

            migrationBuilder.DropIndex(
                name: "IX_supplierMerchandises_SupplierId",
                table: "supplierMerchandises");

            migrationBuilder.DropColumn(
                name: "MerchandiseId",
                table: "supplierMerchandises");

            migrationBuilder.DropColumn(
                name: "SupplierId",
                table: "supplierMerchandises");

            migrationBuilder.CreateIndex(
                name: "IX_supplierMerchandises_MarchandiseId",
                table: "supplierMerchandises",
                column: "MarchandiseId");

            migrationBuilder.CreateIndex(
                name: "IX_supplierMerchandises_SuppplierId",
                table: "supplierMerchandises",
                column: "SuppplierId");

            migrationBuilder.AddForeignKey(
                name: "FK_supplierMerchandises_merchs_MarchandiseId",
                table: "supplierMerchandises",
                column: "MarchandiseId",
                principalTable: "merchs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_supplierMerchandises_suppliers_SuppplierId",
                table: "supplierMerchandises",
                column: "SuppplierId",
                principalTable: "suppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
