using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechWriteServer.Migrations
{
    /// <inheritdoc />
    public partial class oneToOneWithBlog_and_Tag : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tags_Blogs_BlogId",
                table: "Tags");

            migrationBuilder.DropIndex(
                name: "IX_Tags_BlogId",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "BlogId",
                table: "Tags");

            migrationBuilder.AddColumn<int>(
                name: "TagId",
                table: "Blogs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_TagId",
                table: "Blogs",
                column: "TagId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_Tags_TagId",
                table: "Blogs",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "TagId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_Tags_TagId",
                table: "Blogs");

            migrationBuilder.DropIndex(
                name: "IX_Blogs_TagId",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "TagId",
                table: "Blogs");

            migrationBuilder.AddColumn<int>(
                name: "BlogId",
                table: "Tags",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tags_BlogId",
                table: "Tags",
                column: "BlogId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_Blogs_BlogId",
                table: "Tags",
                column: "BlogId",
                principalTable: "Blogs",
                principalColumn: "BlogId");
        }
    }
}
