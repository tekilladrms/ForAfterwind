using Microsoft.EntityFrameworkCore.Migrations;

namespace ForAfterwind.Migrations
{
    public partial class AddMarkersAndPoints : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "PhotoAlbums",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsOnMap",
                table: "PhotoAlbums",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    LAT = table.Column<string>(nullable: true),
                    LNG = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PhotoAlbums_CityId",
                table: "PhotoAlbums",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_PhotoAlbums_Cities_CityId",
                table: "PhotoAlbums",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PhotoAlbums_Cities_CityId",
                table: "PhotoAlbums");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropIndex(
                name: "IX_PhotoAlbums_CityId",
                table: "PhotoAlbums");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "PhotoAlbums");

            migrationBuilder.DropColumn(
                name: "IsOnMap",
                table: "PhotoAlbums");
        }
    }
}
