using ForAfterwind.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace ForAfterwind.Domain
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Musician> Musicians { get; set; }

        public DbSet<SocialLink> SocialLinks { get; set; }

        public DbSet<Skill> Skills { get; set; }

        public DbSet<Release> Releases { get; set; }

        public DbSet<Song> Songs { get; set; }

        public DbSet<VideoAlbum> VideoAlbums { get; set; }

        public DbSet<Video> Videos { get; set; }

        public DbSet<PhotoAlbum> PhotoAlbums { get; set; }

        public DbSet<Photo> Photos { get; set; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<Tag> Tags { get; set; }

        public DbSet<PostCover> PostCovers { get; set; }
        
    }
}
