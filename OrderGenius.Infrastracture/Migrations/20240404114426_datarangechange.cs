using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderGenius.Infrastracture.Migrations
{
    /// <inheritdoc />
    public partial class datarangechange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Qunatity",
                table: "OrderDetail",
                type: "decimal(18,5)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(6,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "OrderDetail",
                type: "decimal(18,5)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(6,5)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Qunatity",
                table: "OrderDetail",
                type: "decimal(6,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,5)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "OrderDetail",
                type: "decimal(6,5)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,5)");
        }
    }
}
