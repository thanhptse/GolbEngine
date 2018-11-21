using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GolbEngine.Models;
using GolbEngine.Application.Services.Interfaces;
using GolbEngine.Application.ViewModels.Blog;

namespace GolbEngine.Controllers
{
    public class HomeController : Controller
    {
        private IBlogService _blogService;
        private ICategoryService _categoryService;

        public HomeController(IBlogService blogService, ICategoryService categoryService)
        {
            _blogService = blogService;
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            HomeViewModel model = new HomeViewModel();
            model.Blogs = _blogService.GetAll();
            model.Categoris = _categoryService.GetAll();

            return View(model);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Course()
        {
            return View();
        }
    }
}
