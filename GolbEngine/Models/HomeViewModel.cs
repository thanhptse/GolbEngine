using GolbEngine.Application.ViewModels.Blog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GolbEngine.Models
{
    public class HomeViewModel
    {
        public List<BlogViewModel> Blogs { get; set; }
        public List<CategoryViewModel> Categoris { get; set; }
    }
}
