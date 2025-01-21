using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechWriteServer.Migrations
{
    /// <inheritdoc />
    public partial class AddBlogLikeTable_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogLike_Blogs_BlogId",
                table: "BlogLike");

            migrationBuilder.DropForeignKey(
                name: "FK_BlogLike_Users_UserId",
                table: "BlogLike");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BlogLike",
                table: "BlogLike");

            migrationBuilder.RenameTable(
                name: "BlogLike",
                newName: "BlogLikes");

            migrationBuilder.RenameIndex(
                name: "IX_BlogLike_UserId",
                table: "BlogLikes",
                newName: "IX_BlogLikes_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_BlogLike_BlogId",
                table: "BlogLikes",
                newName: "IX_BlogLikes_BlogId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BlogLikes",
                table: "BlogLikes",
                column: "BlogLikeId");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogLikes_Blogs_BlogId",
                table: "BlogLikes",
                column: "BlogId",
                principalTable: "Blogs",
                principalColumn: "BlogId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BlogLikes_Users_UserId",
                table: "BlogLikes",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogLikes_Blogs_BlogId",
                table: "BlogLikes");

            migrationBuilder.DropForeignKey(
                name: "FK_BlogLikes_Users_UserId",
                table: "BlogLikes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BlogLikes",
                table: "BlogLikes");

            migrationBuilder.RenameTable(
                name: "BlogLikes",
                newName: "BlogLike");

            migrationBuilder.RenameIndex(
                name: "IX_BlogLikes_UserId",
                table: "BlogLike",
                newName: "IX_BlogLike_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_BlogLikes_BlogId",
                table: "BlogLike",
                newName: "IX_BlogLike_BlogId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BlogLike",
                table: "BlogLike",
                column: "BlogLikeId");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogLike_Blogs_BlogId",
                table: "BlogLike",
                column: "BlogId",
                principalTable: "Blogs",
                principalColumn: "BlogId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BlogLike_Users_UserId",
                table: "BlogLike",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
