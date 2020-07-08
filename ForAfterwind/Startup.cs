using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ForAfterwind.Domain;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ForAfterwind
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(
                x => x.UseSqlServer(
                    @"Data Source=(localdb)\MSSQLLocalDB; Database=Db_Afterwind; Persist Security Info=false; MultipleActiveResultSets=True; Trusted_Connection=true;"));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Latest);
            services.AddMvc(options => options.EnableEndpointRouting = false);
            //services.AddRazorPages();

        }

        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            
            app.UseStaticFiles();
            
            
            app.UseMvc(routes =>
            {
                //routes.MapRoute(
                //    name: "blog",
                //    template: "{controller=Blog}/{action=Article}/{UrlSlug?}");

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

            });
            
        }
    }
}
