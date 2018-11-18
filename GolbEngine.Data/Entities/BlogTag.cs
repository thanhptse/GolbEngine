﻿using GolbEngine.Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GolbEngine.Data.Entities
{
    [Table("BlogTags")]
    public class BlogTag : DomainEntity<int>
    {
        public int BlogId { get; set; }
        public int TagId { get; set; }

        public virtual Blog Blog { get; set; }
        public virtual Tag Tag { get; set; }

        public BlogTag()
        {

        }
    }
}
