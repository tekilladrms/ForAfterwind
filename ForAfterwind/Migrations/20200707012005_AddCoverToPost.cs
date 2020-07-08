using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ForAfterwind.Migrations
{
    public partial class AddCoverToPost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostCovers_Posts_PostId",
                table: "PostCovers");

            migrationBuilder.DropIndex(
                name: "IX_PostCovers_PostId",
                table: "PostCovers");

            migrationBuilder.DropColumn(
                name: "CoverId",
                table: "Posts");

            migrationBuilder.AddColumn<byte[]>(
                name: "Cover",
                table: "Posts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CoverMimeType",
                table: "Posts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cover",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "CoverMimeType",
                table: "Posts");

            migrationBuilder.AddColumn<int>(
                name: "CoverId",
                table: "Posts",
                type: "int",
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
    }
}
