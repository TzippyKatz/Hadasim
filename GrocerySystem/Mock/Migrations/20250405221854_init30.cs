using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mock.Migrations
{
    public partial class init30 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_supplierMerchandises_merchs_MerchandiseId",
                table: "supplierMerchandises");

            migrationBuilder.DropForeignKey(
                name: "FK_supplierMerchandises_suppliers_SupplierId",
                table: "supplierMerchandises");

            migrationBuilder.DropColumn(
                name: "MarchandiseId",
                table: "supplierMerchandises");

            migrationBuilder.DropColumn(
                name: "SuppplierId",
                table: "supplierMerchandises");

            migrationBuilder.AlterColumn<int>(
                name: "SupplierId",
                table: "supplierMerchandises",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MerchandiseId",
                table: "supplierMerchandises",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_supplierMerchandises_merchs_MerchandiseId",
                table: "supplierMerchandises",
                column: "MerchandiseId",
                principalTable: "merchs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_supplierMerchandises_suppliers_SupplierId",
                table: "supplierMerchandises",
                column: "SupplierId",
                principalTable: "suppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_supplierMerchandises_merchs_MerchandiseId",
                table: "supplierMerchandises");

            migrationBuilder.DropForeignKey(
                name: "FK_supplierMerchandises_suppliers_SupplierId",
                table: "supplierMerchandises");

            migrationBuilder.AlterColumn<int>(
                name: "SupplierId",
                table: "supplierMerchandises",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "MerchandiseId",
                table: "supplierMerchandises",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "MarchandiseId",
                table: "supplierMerchandises",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SuppplierId",
                table: "supplierMerchandises",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
    }
}
