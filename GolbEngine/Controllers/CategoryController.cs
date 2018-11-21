using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GolbEngine.Application.Services.Interfaces;
using GolbEngine.Models;
using Microsoft.AspNetCore.Mvc;

namespace GolbEngine.Controllers
{
    public class CategoryController : Controller
    {
        private IBlogService _blogService;
        private ICategoryService _categoryService;

        public CategoryController(IBlogService blogService, ICategoryService categoryService)
        {
            _blogService = blogService;
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Detail(int categoryId)
        {
            CategoryDetailViewModel model = new CategoryDetailViewModel();
            model.Category = _categoryService.GetById(categoryId);
            model.Blogs = _blogService.GetBlogByCategoryId(categoryId);

            return View(model);
        }
    }
}