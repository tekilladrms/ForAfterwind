using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ForAfterwind.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ForAfterwind.Controllers
{
    public class BlogController : Controller
    {
        AppDbContext db;
        public BlogController(AppDbContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            return View(db.Posts.AsNoTracking());
        }

        [HttpGet]
        public async Task<IActionResult> Article(int id)
        {
            return View(await db.Posts.AsNoTracking().FirstOrDefaultAsync(post => post.Id == id));
        }

    }
}