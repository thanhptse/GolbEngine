using GolbEngine.Data.Interfaces;
using GolbEngine.Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using GolbEngine.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace GolbEngine.Data.Entities
{
    [Table("Blogs")]
    public class Blog : DomainEntity<int>, IDateTracking, ISwitchable, IHasSoftDelete
    {
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
        public bool? HotFlag { set; get; }
        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
        public ICollection<BlogTag> BlogTags { get; } = new List<BlogTag>();

        public Blog()
        {

        }

        public Blog(string name, string image, string description, string content, int categoryId, string tags)
        {
            Name = name;
            Image = image;
            Description = description;
            Content = content;
            CategoryId = categoryId;
            Tags = tags;
        }
    }
}
