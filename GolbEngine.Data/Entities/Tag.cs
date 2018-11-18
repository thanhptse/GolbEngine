using GolbEngine.Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GolbEngine.Data.Entities
{
    [Table("Tags")]
    public class Tag : DomainEntity<int>
    {
        public string Name { get; set; }
        public ICollection<BlogTag> BlogTags { get; } = new List<BlogTag>();
    }
}
