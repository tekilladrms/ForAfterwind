using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ForAfterwind.Domain;
using ForAfterwind.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ForAfterwind.Controllers
{
    public class HomeController : Controller
    {
        private AppDbContext db;
        public HomeController(AppDbContext context)
        {
            db = context;
        }

        [Route("/")]
        [Route("/Home")]
        public async Task<IActionResult> Index()
        {
            HomePageViewModel model = new HomePageViewModel();

            model.progressBars = await db.ProgressBars
                .Where(bar => bar.IsActive == true)
                .Include(bar => bar.albumStages)
                .AsNoTracking()
                .ToListAsync();

            model.greetings = await db.Greetings
                .Where(greeting => greeting.IsActive == true)
                .AsNoTracking().ToListAsync();
            

            return View(model);
        }
    }
}