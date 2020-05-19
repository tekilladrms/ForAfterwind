using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ForAfterwind.Domain;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace ForAfterwind
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //using (AppDbContext db = new AppDbContext())
            //{
            //    Musician mus1 = new Musician { Name = "Gregory Kotlovsky" };
            //    Musician mus2 = new Musician { Name = "Andrew Voronin" };
            //    Musician mus3 = new Musician { Name = "Dmitry Tishkov" };

            //    db.Musicians.Add(mus1);
            //    db.Musicians.Add(mus2);
            //    db.Musicians.Add(mus3);
            //    db.SaveChanges();
            //}
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
