using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ForAfterwind.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Band()
        {
            return View();
        }

        public IActionResult Musicians()
        {
            return View();
        }
    }
}