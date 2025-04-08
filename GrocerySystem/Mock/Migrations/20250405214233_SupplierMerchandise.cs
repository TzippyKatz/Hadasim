using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mock.Migrations
{
    public partial class SupplierMerchandise : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "orderItems");

            migrationBuilder.DropColumn(
                name: "MerchandiseId",
                table: "suppliers");

            migrationBuilder.CreateTable(
                name: "supplierMerchandises",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SuppplierId = table.Column<int>(type: "int", nullable: false),
                    MarchandiseId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_supplierMerchandises", x => x.Id);
                    table.ForeignKey(
                        name: "FK_supplierMerchandises_merchs_MarchandiseId",
                        column: x => x.MarchandiseId,
                        principalTable: "merchs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_supplierMerchandises_suppliers_SuppplierId",
                        column: x => x.SuppplierId,
                        principalTable: "suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_supplierMerchandises_MarchandiseId",
                table: "supplierMerchandises",
                column: "MarchandiseId");

            migrationBuilder.CreateIndex(
                name: "IX_supplierMerchandises_SuppplierId",
                table: "supplierMerchandises",
                column: "SuppplierId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "supplierMerchandises");

            migrationBuilder.AddColumn<int>(
                name: "MerchandiseId",
                table: "suppliers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "orderItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MarchandiseId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orderItems", x => x.Id);
                });
        }
    }
}
