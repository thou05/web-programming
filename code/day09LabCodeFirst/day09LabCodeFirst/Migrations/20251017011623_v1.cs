using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace day09LabCodeFirst.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LttLoaiSanPham",
                columns: table => new
                {
                    lttId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    lttMaLoai = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    lttTenLoai = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    lttTrangThai = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LttLoaiSanPham", x => x.lttId);
                });

            migrationBuilder.CreateTable(
                name: "LttSanPham",
                columns: table => new
                {
                    lttId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    lttMaSP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lttTenSP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lttHinhAnh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lttSoLuong = table.Column<int>(type: "int", nullable: false),
                    lttGiaBan = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    lttMaLoai = table.Column<long>(type: "bigint", nullable: false),
                    lttTrangThai = table.Column<bool>(type: "bit", nullable: false),
                    LttLoaiSanPhamlttId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LttSanPham", x => x.lttId);
                    table.ForeignKey(
                        name: "FK_LttSanPham_LttLoaiSanPham_LttLoaiSanPhamlttId",
                        column: x => x.LttLoaiSanPhamlttId,
                        principalTable: "LttLoaiSanPham",
                        principalColumn: "lttId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LttSanPham_LttLoaiSanPhamlttId",
                table: "LttSanPham",
                column: "LttLoaiSanPhamlttId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LttSanPham");

            migrationBuilder.DropTable(
                name: "LttLoaiSanPham");
        }
    }
}
