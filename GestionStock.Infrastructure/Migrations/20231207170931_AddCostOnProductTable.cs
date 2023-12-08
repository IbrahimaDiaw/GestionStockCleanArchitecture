using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionStock.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddCostOnProductTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Cost",
                table: "products",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cost",
                table: "products");
        }
    }
}
