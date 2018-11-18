using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GolbEngine.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace GolbEngine.Areas.Admin.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController()
        {
        }

        public IActionResult Index()
        {
            var email = User.GetSpecificClaim("Email");

            return View();
        }
    }
}