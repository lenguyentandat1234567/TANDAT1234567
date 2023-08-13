using Microsoft.EntityFrameworkCore.Migrations;
using static System.Data.Entity.Migrations.Model.UpdateDatabaseOperation;

#nullable disable

namespace QuanLyThuVien.Migrations
{
   
    public partial class dbinit : Migration
    {
    
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LoaiSachs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenLoai = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiSachs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sachs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ten = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sachs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ViTris",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ke = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ViTris", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LoaiSach_Sachs",
                columns: table => new
                {
                    SachId = table.Column<int>(type: "int", nullable: false),
                    LoaiSachId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiSach_Sachs", x => new { x.LoaiSachId, x.SachId });
                    table.ForeignKey(
                        name: "FK_LoaiSach_Sachs_LoaiSachs_LoaiSachId",
                        column: x => x.LoaiSachId,
                        principalTable: "LoaiSachs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LoaiSach_Sachs_Sachs_SachId",
                        column: x => x.SachId,
                        principalTable: "Sachs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ViTri_Sachs",
                columns: table => new
                {
                    ViTriId = table.Column<int>(type: "int", nullable: false),
                    SachId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ViTri_Sachs", x => new { x.ViTriId, x.SachId });
                    table.ForeignKey(
                        name: "FK_ViTri_Sachs_Sachs_SachId",
                        column: x => x.SachId,
                        principalTable: "Sachs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ViTri_Sachs_ViTris_ViTriId",
                        column: x => x.ViTriId,
                        principalTable: "ViTris",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LoaiSach_Sachs_SachId",
                table: "LoaiSach_Sachs",
                column: "SachId");

            migrationBuilder.CreateIndex(
                name: "IX_ViTri_Sachs_SachId",
                table: "ViTri_Sachs",
                column: "SachId");
        }

       
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LoaiSach_Sachs");

            migrationBuilder.DropTable(
                name: "ViTri_Sachs");

            migrationBuilder.DropTable(
                name: "LoaiSachs");

            migrationBuilder.DropTable(
                name: "Sachs");

            migrationBuilder.DropTable(
                name: "ViTris");
        }
    }
}