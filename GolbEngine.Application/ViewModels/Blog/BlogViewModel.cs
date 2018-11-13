using GolbEngine.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GolbEngine.Application.ViewModels.Blog
{
    public class BlogViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int CategoryId { get; set; }
        public string Content { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public Status Status { get; set; }
        public bool IsDeleted { get; set; }
        public CategoryViewModel Category { get; set; }
    }
}
