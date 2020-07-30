using Microsoft.EntityFrameworkCore.Migrations;

namespace ForAfterwind.Migrations
{
    public partial class AddProgressBarsAndDeleteIsActiveFromAlbumStage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "AlbumStages");

            migrationBuilder.AddColumn<int>(
                name: "ProgressBarId",
                table: "AlbumStages",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ProgressBars",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgressBars", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProgressBars");

            migrationBuilder.DropColumn(
                name: "ProgressBarId",
                table: "AlbumStages");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "AlbumStages",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
