using GolbEngine.Data.Interfaces;
using GolbEngine.Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using GolbEngine.Data.Enums;

namespace GolbEngine.Data.Entities
{
    [Table("Blogs")]
    public class Blog : DomainEntity<int>, IDateTracking, ISwitchable, IHasSoftDelete
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public Status Status { get; set; }
        public bool IsDeleted { get; set; }
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
        public ICollection<BlogTag> BlogTags { get; } = new List<BlogTag>();

        public Blog()
        {

        }

        public Blog(string title, string content, Status status, int categoryId)
        {
            Title = title;
            Content = content;
            Status = status;
            CategoryId = categoryId;
            IsDeleted = false;
        }

        public Blog(int id, string title, string content, Status status, int categoryId)
        {
            Id = id;
            Title = title;
            Content = content;
            Status = status;
            CategoryId = categoryId;
            IsDeleted = false;
        }
    }
}
