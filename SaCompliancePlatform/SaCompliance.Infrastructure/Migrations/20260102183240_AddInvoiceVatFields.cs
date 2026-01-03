using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SaCompliance.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddInvoiceVatFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "Invoices",
                newName: "Total");

            migrationBuilder.AddColumn<decimal>(
                name: "SubTotal",
                table: "Invoices",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubTotal",
                table: "Invoices");

            migrationBuilder.RenameColumn(
                name: "Total",
                table: "Invoices",
                newName: "Amount");
        }
    }
}
