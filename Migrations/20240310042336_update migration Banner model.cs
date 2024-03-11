using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GundamStore.Migrations
{
    public partial class updatemigrationBannermodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Banners",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreateBy = table.Column<int>(type: "int", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdateBy = table.Column<int>(type: "int", nullable: false),
                    DeleteFlag = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banners", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Banners");
        }
    }
}
