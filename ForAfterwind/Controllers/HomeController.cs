using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ForAfterwind.Controllers
{
    public class HomeController : Controller
    {

        [Route("/")]
        [Route("/Home")]
        public IActionResult Index()
        {
            return View();
        }
    }
}