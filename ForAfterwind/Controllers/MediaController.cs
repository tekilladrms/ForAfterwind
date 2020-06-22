using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ForAfterwind.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ForAfterwind.Controllers
{
    public class MediaController : Controller
    {
        AppDbContext db;
        public MediaController(AppDbContext context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Video()
        {
            var videoAlbums = db.VideoAlbums.Include(x => x.Videos);

            return View(videoAlbums);
        }

        public IActionResult Audio()
        {
            var releases = db.Releases.Include(x => x.Songs);
            return View(releases);
        }

        public IActionResult Photo()
        {
            var photoAlbums = db.PhotoAlbums.Include(x => x.Photos);
            return View(photoAlbums);
        }
    }
}