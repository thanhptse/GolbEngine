using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GolbEngine.Application.Services.Interfaces;
using GolbEngine.Models;
using Microsoft.AspNetCore.Mvc;

namespace GolbEngine.Controllers
{
    public class TagController : Controller
    {
        private IBlogService _blogService;
        private ITagService _tagService;

        public TagController(IBlogService blogService, ITagService tagService)
        {
            _blogService = blogService;
            _tagService = tagService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Detail(string tagId)
        {
            TagDetailViewModel model = new TagDetailViewModel();
            model.Tag = _tagService.GetById(tagId);
            model.Blogs = _blogService.GetListByTagId(tagId);

            return View(model);
        }
    }
}