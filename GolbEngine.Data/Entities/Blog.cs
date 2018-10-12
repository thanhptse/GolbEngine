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
        public virtual Category Category { get; set; }
    }
}
