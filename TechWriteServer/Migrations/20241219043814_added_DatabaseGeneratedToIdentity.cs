using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechWriteServer.Migrations
{
    /// <inheritdoc />
    public partial class added_DatabaseGeneratedToIdentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "Blogs",
                type: "bit",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "Blogs");
        }
    }
}
