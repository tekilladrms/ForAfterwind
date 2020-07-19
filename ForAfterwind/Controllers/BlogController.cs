using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ForAfterwind.Domain;
using ForAfterwind.Models;
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

        [HttpGet]
        [Route("Blog")]
        [Route("Blog/Index")]
        public IActionResult Index()
        {
            return View(allPosts);
        }



        [HttpGet]
        //[Route("Blog/Article/{UrlSlug?}")]
        public IActionResult Article(string urlSlug)
        {
            //ViewBag.OtherPosts = allPosts.Where(post => post.Id != id).ToList();
            //return View(allPosts.FirstOrDefault(post => post.Id == id));

            if (urlSlug == null)
            {
                return NotFound();
            }

            ViewBag.OtherPosts = allPosts.Where(post => post.UrlSlug != urlSlug).ToList();
            return View(allPosts.FirstOrDefault(post => post.UrlSlug == urlSlug));

        }




    }
}