using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ForAfterwind.Domain;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace ForAfterwind
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();

            try
            {
                var scope = host.Services.CreateScope();

                var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                context.Database.EnsureCreated();

                var adminRole = new IdentityRole("Admin");

                if (!context.Roles.Any())
                {
                    // Create a role
                    roleManager.CreateAsync(adminRole).GetAwaiter().GetResult();
                    
                }

                if (!context.Users.Any(u => u.UserName == "admin"))
                {
                    // Create an admin
                    var adminUser = new IdentityUser
                    {
                        UserName = "admin"
                    };

                    var result = userManager.CreateAsync(adminUser, "password").GetAwaiter().GetResult();

                    // add role to user

                    userManager.AddToRoleAsync(adminUser, adminRole.Name).GetAwaiter().GetResult();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            host.Run();
        }


        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    //.UseKestrel(options =>
    //{

        //    options.Limits.MaxRequestBodySize = 100000000;

        //}
        //)
    };
}

