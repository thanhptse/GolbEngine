using System;
using System.Collections.Generic;
using System.Text;

namespace GolbEngine.Application.ViewModels.Blog
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public CategoryViewModel OwnerId { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public int Order { get; set; }
        public ICollection<BlogViewModel> Blogs { get; set; }
    }
}
