using GolbEngine.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GolbEngine.Data.EntityFramework
{
    public class AppDbContext
    {
        public DbSet<Blog> Blog { get; set; }
        public DbSet<BlogTag> BlogTag { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Tag> Tags { get; set; }
    }
}
