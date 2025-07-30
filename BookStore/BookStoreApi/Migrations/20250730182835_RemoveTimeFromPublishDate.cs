using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStoreApi.Migrations;

/// <inheritdoc />
public partial class RemoveTimeFromPublishDate : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.AlterColumn<DateOnly>(
            name: "publish_date",
            table: "book",
            type: "date",
            nullable: false,
            oldClrType: typeof(DateTime),
            oldType: "datetime(6)");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.AlterColumn<DateTime>(
            name: "publish_date",
            table: "book",
            type: "datetime(6)",
            nullable: false,
            oldClrType: typeof(DateOnly),
            oldType: "date");
    }
}
