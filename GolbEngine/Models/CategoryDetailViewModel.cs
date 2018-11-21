using GolbEngine.Application.ViewModels.Blog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GolbEngine.Models
{
    public class CategoryDetailViewModel
    {
        public CategoryViewModel Category { get; set; }
        public List<BlogViewModel> Blogs { get; set; }
    }
}
