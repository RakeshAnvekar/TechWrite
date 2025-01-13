using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechWriteServer.Migrations
{
    /// <inheritdoc />
    public partial class addedIsActiveClmToTag : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Tags",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Tags");
        }
    }
}
