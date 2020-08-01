using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ForAfterwind.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ForAfterwind.Controllers
{
    public class AboutController : Controller
    {
        AppDbContext db;
        public AboutController(AppDbContext context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Band()
        {
            return View();
        }

        public async Task<IActionResult> Musicians()
        {
            var musicians = await db.Musicians
                .Include(x => x.SocialLinks)
                .Include(x => x.Skills)
                .AsNoTracking()
                .ToListAsync();
            
            
            return View(musicians);
        }
        
    }
}