using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace GolbEngine.Controllers
{
    public class PostController : Controller
    {
        public IActionResult Detail()
        {
            return View();
        }

        public IActionResult GoodPost()
        {
            return View();
        }
    }
}