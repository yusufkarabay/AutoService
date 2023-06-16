using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoService.WebUI.Migrations
{
    /// <inheritdoc />
    public partial class customeredited : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhoneNum",
                table: "Customers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhoneNum",
                table: "Customers",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
