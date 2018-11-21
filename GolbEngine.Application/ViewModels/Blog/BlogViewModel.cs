using GolbEngine.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GolbEngine.Application.ViewModels.Blog
{
    public class BlogViewModel
    {
        public int Id { set; get; }
        [Required]
        [MaxLength(256)]
        public string Name { get; set; }
        [MaxLength(256)]
        public string Image { set; get; }
        [MaxLength(500)]
        public string Description { set; get; }
        public string Content { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public Status Status { get; set; }
        public bool IsDeleted { get; set; }
        public int CategoryId { get; set; }
        public string Tags { get; set; }
        public int? ViewCount { set; get; }
        public bool? HomeFlag { set; get; }
        public CategoryViewModel Category { get; set; }
    }
}
