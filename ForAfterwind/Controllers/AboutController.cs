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
        AppDbContext db = new AppDbContext();
        public AboutController()
        {
            
        }
        public IActionResult Band()
        {
            return View();
        }

        public IActionResult Musicians()
        {
            var musicians = db.Musicians.Include(x => x.SocialLinks).Include(x => x.Skills);
            
            
            return View(musicians);
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}