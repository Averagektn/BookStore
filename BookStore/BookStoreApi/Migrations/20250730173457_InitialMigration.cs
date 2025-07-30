using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStoreApi.Migrations;

/// <inheritdoc />
public partial class InitialMigration : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.AlterDatabase()
            .Annotation("MySql:CharSet", "utf8mb4");

        _ = migrationBuilder.CreateTable(
            name: "book",
            columns: table => new
            {
                id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                title = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                decription = table.Column<string>(type: "varchar(1024)", maxLength: 1024, nullable: true)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                author = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                price = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                publish_date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                slock_quantity = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                _ = table.PrimaryKey("PK_book", x => x.id);
            })
            .Annotation("MySql:CharSet", "utf8mb4");

        _ = migrationBuilder.CreateTable(
            name: "order",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                created_at = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                total_price = table.Column<decimal>(type: "decimal(65,30)", nullable: false)
            },
            constraints: table =>
            {
                _ = table.PrimaryKey("PK_order", x => x.Id);
            })
            .Annotation("MySql:CharSet", "utf8mb4");

        _ = migrationBuilder.CreateTable(
            name: "order_book",
            columns: table => new
            {
                order_id = table.Column<int>(type: "int", nullable: false),
                book_id = table.Column<int>(type: "int", nullable: false),
                quantity = table.Column<int>(type: "int", nullable: false),
                price = table.Column<decimal>(type: "decimal(65,30)", nullable: false)
            },
            constraints: table =>
            {
                _ = table.PrimaryKey("PK_order_book", x => new { x.book_id, x.order_id });
                _ = table.ForeignKey(
                    name: "FK_order_book_book_book_id",
                    column: x => x.book_id,
                    principalTable: "book",
                    principalColumn: "id",
                    onDelete: ReferentialAction.Restrict);
                _ = table.ForeignKey(
                    name: "FK_order_book_order_order_id",
                    column: x => x.order_id,
                    principalTable: "order",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            })
            .Annotation("MySql:CharSet", "utf8mb4");

        _ = migrationBuilder.CreateIndex(
            name: "IX_book_author_title",
            table: "book",
            columns: new[] { "author", "title" },
            unique: true);

        _ = migrationBuilder.CreateIndex(
            name: "IX_order_book_order_id",
            table: "order_book",
            column: "order_id");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.DropTable(
            name: "order_book");

        _ = migrationBuilder.DropTable(
            name: "book");

        _ = migrationBuilder.DropTable(
            name: "order");
    }
}
