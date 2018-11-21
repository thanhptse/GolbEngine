using GolbEngine.Data.Interfaces;
using GolbEngine.Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GolbEngine.Data.Entities
{
    [Table("Categories")]
    public class Category : DomainEntity<int>, IHasOwner<Category>, IHasSoftDelete, IDateTracking
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Category OwnerId { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public int Order { get; set; }
        public virtual ICollection<Blog> Blogs { get; set; }
    }
}
