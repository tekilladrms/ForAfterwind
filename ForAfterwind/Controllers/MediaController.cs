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
        AppDbContext db = new AppDbContext();

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Video()
        {
            return View();
        }

        public IActionResult Audio()
        {
            var releases = db.Releases.Include(x => x.Songs);
            return View(releases);
        }

        public IActionResult Photo()
        {
            return View();
        }
    }
}