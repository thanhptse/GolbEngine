using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GolbEngine.Application.Services.Interfaces;
using GolbEngine.Application.ViewModels.Blog;
using GolbEngine.Models;
using Microsoft.AspNetCore.Mvc;

namespace GolbEngine.Controllers
{
    public class PostController : Controller
    {
        private IBlogService _blogService;
        private ICategoryService _categoryService;


        public PostController(IBlogService blogService, ICategoryService categoryService)
        {
            _blogService = blogService;
            _categoryService = categoryService;
        }

        public IActionResult Detail(int blogId)
        {
            //increase view count
            _blogService.IncreaseView(blogId);
            _blogService.Save();

            BlogDetailViewModel model = new BlogDetailViewModel();

            model.Blog = _blogService.GetById(blogId);
            model.Category = _categoryService.GetById(model.Blog.CategoryId);
            model.Tags = _blogService.GetBlogTags(blogId);
            model.RelatedBlogs = _blogService.GetReatedBlogs(4);

            return View(model);
        }

        public IActionResult GoodPost()
        {
            List<BlogViewModel> goodPosts = _blogService.GetGoodPost();
            return View(goodPosts);
        }
    }
}