using Microsoft.EntityFrameworkCore.Migrations;

namespace ForAfterwind.Migrations
{
    public partial class AddPathToPhotoAlbum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PathToPhotoAlbum",
                table: "PhotoAlbums",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PathToPhotoAlbum",
                table: "PhotoAlbums");
        }
    }
}
