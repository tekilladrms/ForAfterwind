using Microsoft.EntityFrameworkCore.Migrations;

namespace ForAfterwind.Migrations
{
    public partial class AddColorToProgressBar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Color",
                table: "ProgressBars",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "ProgressBarId",
                table: "AlbumStages",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_AlbumStages_ProgressBarId",
                table: "AlbumStages",
                column: "ProgressBarId");

            migrationBuilder.AddForeignKey(
                name: "FK_AlbumStages_ProgressBars_ProgressBarId",
                table: "AlbumStages",
                column: "ProgressBarId",
                principalTable: "ProgressBars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AlbumStages_ProgressBars_ProgressBarId",
                table: "AlbumStages");

            migrationBuilder.DropIndex(
                name: "IX_AlbumStages_ProgressBarId",
                table: "AlbumStages");

            migrationBuilder.DropColumn(
                name: "Color",
                table: "ProgressBars");

            migrationBuilder.AlterColumn<int>(
                name: "ProgressBarId",
                table: "AlbumStages",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
