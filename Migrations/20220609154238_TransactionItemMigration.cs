using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EggStore.Migrations
{
    public partial class TransactionItemMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(
                name: "transaction_items",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    transaction_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    egg_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transaction_items", x => x.id);
                    table.ForeignKey(
                        name: "FK_transaction_items_eggs_egg_id",
                        column: x => x.egg_id,
                        principalTable: "eggs",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_transaction_items_transactions_transaction_id",
                        column: x => x.transaction_id,
                        principalTable: "transactions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_transaction_items_transaction_id",
                table: "transaction_items",
                column: "transaction_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "transaction_items");
        }
    }
}
