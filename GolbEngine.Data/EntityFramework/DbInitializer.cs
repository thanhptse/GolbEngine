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
                Category cate1 = new Category { Name = "Chuyện nghề nghiệp", Description = "Chuyện nghề nghiệp" };
                Category cate2 = new Category { Name = "Chuyện lập trình", Description = "Chuyện lập trình" };
                Category cate3 = new Category { Name = "Chuyện bên lề", Description = "Chuyện bên lề" };
                Category cate4 = new Category { Name = "Chuyện cuộc sống", Description = "Chuyện cuộc sống" };
                Category cate5 = new Category { Name = "Linux - ubuntu", Description = "Linux - ubuntu" };

                Tag tagTest = new Tag { Name = "test" };

                Blog blog1 = new Blog { Name = "Demo 1", Description = "hihi", Image = "demo.jpg", Content = "Hello 1", Status = Status.Active, Category = cate1 };
                Blog blog2 = new Blog { Name = "Demo 2", Description = "hihi", Image = "demo.jpg", Content = "Hello 2", Status = Status.Active, Category = cate2 };

                BlogTag blogTag1 = new BlogTag { Blog = blog1, Tag = tagTest };
                BlogTag blogTag2 = new BlogTag { Blog = blog2, Tag = tagTest };

                _context.Categories.AddRange(cate1, cate2, cate3, cate4, cate5);
                _context.Tags.AddRange(tagTest);
                _context.Blogs.AddRange(blog1, blog2);
                _context.BlogTags.AddRange(blogTag1, blogTag2);

            }

            if (_context.Functions.Count() == 0)
            {
                _context.Functions.AddRange(new List<Function>()
                {
                    
                    new Function() {Id = "CONTENT",Name = "Content",ParentId = null,SortOrder = 1,Status = Status.Active,URL = "/",IconCss = "fa-table"  },
                    new Function() {Id = "BLOG",Name = "Blog",ParentId = "CONTENT",SortOrder = 1,Status = Status.Active,URL = "/admin/blog/index",IconCss = "fa-table"  },
                    new Function() {Id = "PAGE",Name = "Page",ParentId = "CONTENT",SortOrder = 2,Status = Status.InActive,URL = "/admin/page/index",IconCss = "fa-table"  },

                    new Function() {Id = "SYSTEM", Name = "System",ParentId = null,SortOrder = 2,Status = Status.Active,URL = "/",IconCss = "fa-desktop"  },
                    new Function() {Id = "ROLE", Name = "Role",ParentId = "SYSTEM",SortOrder = 1,Status = Status.InActive,URL = "/admin/role/index",IconCss = "fa-home"  },
                    new Function() {Id = "FUNCTION", Name = "Function",ParentId = "SYSTEM",SortOrder = 2,Status = Status.InActive,URL = "/admin/function/index",IconCss = "fa-home"  },
                    new Function() {Id = "USER", Name = "User",ParentId = "SYSTEM",SortOrder =3,Status = Status.InActive,URL = "/admin/user/index",IconCss = "fa-home"  },
                    new Function() {Id = "ACTIVITY", Name = "Activity",ParentId = "SYSTEM",SortOrder = 4,Status = Status.InActive,URL = "/admin/activity/index",IconCss = "fa-home"  },
                    new Function() {Id = "ERROR", Name = "Error",ParentId = "SYSTEM",SortOrder = 5,Status = Status.InActive,URL = "/admin/error/index",IconCss = "fa-home"  },
                    new Function() {Id = "SETTING", Name = "Configuration",ParentId = "SYSTEM",SortOrder = 6,Status = Status.InActive,URL = "/admin/setting/index",IconCss = "fa-home"  },


                    new Function() {Id = "UTILITY",Name = "Utilities",ParentId = null,SortOrder = 3,Status = Status.Active,URL = "/",IconCss = "fa-clone"  },
                    new Function() {Id = "FOOTER",Name = "Footer",ParentId = "UTILITY",SortOrder = 1,Status = Status.InActive,URL = "/admin/footer/index",IconCss = "fa-clone"  },
                    new Function() {Id = "FEEDBACK",Name = "Feedback",ParentId = "UTILITY",SortOrder = 2,Status = Status.InActive,URL = "/admin/feedback/index",IconCss = "fa-clone"  },
                    new Function() {Id = "ANNOUNCEMENT",Name = "Announcement",ParentId = "UTILITY",SortOrder = 3,Status = Status.InActive,URL = "/admin/announcement/index",IconCss = "fa-clone"  },
                    new Function() {Id = "CONTACT",Name = "Contact",ParentId = "UTILITY",SortOrder = 4,Status = Status.InActive,URL = "/admin/contact/index",IconCss = "fa-clone"  },
                    new Function() {Id = "SLIDE",Name = "Slide",ParentId = "UTILITY",SortOrder = 5,Status = Status.InActive,URL = "/admin/slide/index",IconCss = "fa-clone"  },
                    new Function() {Id = "ADVERTISMENT",Name = "Advertisment",ParentId = "UTILITY",SortOrder = 6,Status = Status.InActive,URL = "/admin/advertistment/index",IconCss = "fa-clone"  },

                });
            }

            await _context.SaveChangesAsync();
        }
    }
}
