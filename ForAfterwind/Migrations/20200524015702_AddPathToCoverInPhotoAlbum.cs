using Microsoft.EntityFrameworkCore.Migrations;

namespace ForAfterwind.Migrations
{
    public partial class AddPathToCoverInPhotoAlbum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PathToCover",
                table: "PhotoAlbums",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PathToCover",
                table: "PhotoAlbums");
        }
    }
}
