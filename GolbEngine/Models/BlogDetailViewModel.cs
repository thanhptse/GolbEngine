using GolbEngine.Application.ViewModels.Blog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GolbEngine.Models
{
    public class BlogDetailViewModel
    {
        public BlogViewModel Blog { get; set; }
        public CategoryViewModel Category { get; set; }
        public List<BlogViewModel> RelatedBlogs { get; set; }
        public List<TagViewModel> Tags { get; set; }
    }
}
