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
        List<Post> allPosts;
        public BlogController(AppDbContext context)
        {
            db = context;
            allPosts = db.Posts.AsNoTracking().ToList();
        }
        public IActionResult Index()
        {
            return View(db.Posts.AsNoTracking());
        }

        [HttpGet]
        public async Task<IActionResult> Article(int id)
        {
            
            //ViewBag.OtherPosts = await db.Posts.AsNoTracking().Where(post => post.Id != id).ToListAsync();
            ViewBag.OtherPosts = allPosts.Where(post => post.Id != id).ToList();
            return View(allPosts.FirstOrDefault(post => post.Id == id));
            //return View()
        }

        

        
    }
}