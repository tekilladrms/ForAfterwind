using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForAfterwind.Domain
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        //public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Musician> Musicians { get; set; }

        public DbSet<SocialLink> SocialLinks { get; set; }

        public DbSet<Skill> Skills { get; set; }

        public DbSet<Release> Releases { get; set; }

        public DbSet<Song> Songs { get; set; }


        public AppDbContext()
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB; Database=Db_Afterwind; Persist Security Info=false; MultipleActiveResultSets=True; Trusted_Connection=true;");
        }
        
    }
}
