using GolbEngine.Data.Entities;
using GolbEngine.Data.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GolbEngine.Data.EntityFramework
{
    public class DbInitializer
    {
        private readonly AppDbContext _context;
        private UserManager<AppUser> _userManager;
        private RoleManager<AppRole> _roleManager;
        public DbInitializer(AppDbContext context, UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task Seed()
        {
            if (!_roleManager.Roles.Any())
            {
                await _roleManager.CreateAsync(new AppRole()
                {
                    Name = "Admin",
                    NormalizedName = "Admin",
                    Description = "Top manager"
                });
            }

            if (!_userManager.Users.Any())
            {
                await _userManager.CreateAsync(new AppUser()
                {
                    UserName = "admin",
                    FullName = "Administrator",
                    Email = "admin@gmail.com",
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    Status = Status.Active
                }, "123Abc$#");
                var user = await _userManager.FindByNameAsync("admin");
                await _userManager.AddToRoleAsync(user, "Admin");
            }

            if (!_context.Blogs.Any() && !_context.Tags.Any() && !_context.Categories.Any())
            {
                Category categoryTest = new Category { Name = "Test Category", Description = "For testing only"};

                Tag tagTest = new Tag { Name = "test" };

                Blog blog1 = new Blog { Title = "Demo 1", Content = "Hello", Status = Status.Active, Category = categoryTest };
                Blog blog2 = new Blog { Title = "Demo 2", Content = "Hello", Status = Status.Active, Category = categoryTest };

                _context.Categories.AddRange(categoryTest);
                _context.Tags.AddRange(tagTest);
                _context.Blogs.AddRange(blog1, blog2);

            }

            await _context.SaveChangesAsync();
        }
    }
}
