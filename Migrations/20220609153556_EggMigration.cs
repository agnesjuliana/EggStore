using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EggStore.Migrations
{
    public partial class EggMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "eggs",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    egg_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    stok = table.Column<int>(type: "int", nullable: false),
                    price = table.Column<double>(type: "float", nullable: false),
                    package_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_eggs", x => x.id);
                    table.ForeignKey(
                        name: "FK_eggs_packages_package_id",
                        column: x => x.package_id,
                        principalTable: "packages",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_eggs_package_id",
                table: "eggs",
                column: "package_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "eggs");
        }
    }
}
