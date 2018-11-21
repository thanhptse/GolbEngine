using GolbEngine.Application.ViewModels.Blog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GolbEngine.Models
{
    public class TagDetailViewModel
    {
        public TagViewModel Tag { get; set; }
        public List<BlogViewModel> Blogs { get; set; }
    }
}
