using Microsoft.EntityFrameworkCore.Migrations;

namespace ForAfterwind.Migrations
{
    public partial class AddingPostIdToPostCover : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_PostCovers_PostCoverId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_PostCoverId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "PostCoverId",
                table: "Posts");

            migrationBuilder.AddColumn<int>(
                name: "PostId",
                table: "PostCovers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PostCovers_PostId",
                table: "PostCovers",
                column: "PostId",
                unique: true,
                filter: "[PostId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_PostCovers_Posts_PostId",
                table: "PostCovers",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostCovers_Posts_PostId",
                table: "PostCovers");

            migrationBuilder.DropIndex(
                name: "IX_PostCovers_PostId",
                table: "PostCovers");

            migrationBuilder.DropColumn(
                name: "PostId",
                table: "PostCovers");

            migrationBuilder.AddColumn<int>(
                name: "PostCoverId",
                table: "Posts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Posts_PostCoverId",
                table: "Posts",
                column: "PostCoverId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_PostCovers_PostCoverId",
                table: "Posts",
                column: "PostCoverId",
                principalTable: "PostCovers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
