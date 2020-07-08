using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ForAfterwind.Migrations
{
    public partial class AddingCoverToPosts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CoverId",
                table: "Posts",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PostCoverId",
                table: "Posts",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PostCovers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostCovers", x => x.Id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_PostCovers_PostCoverId",
                table: "Posts");

            migrationBuilder.DropTable(
                name: "PostCovers");

            migrationBuilder.DropIndex(
                name: "IX_Posts_PostCoverId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "CoverId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "PostCoverId",
                table: "Posts");
        }
    }
}
