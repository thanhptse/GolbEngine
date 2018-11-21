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
                Category cate1 = new Category { Name = "Chuyện nghề nghiệp", Description = "Chuyện nghề nghiệp - là chuyên mục nơi một thằng coder viết về những buồn vui, khó khăn, trăn trở trong nghề lập trình.", Order = 1 };
                Category cate2 = new Category { Name = "Chuyện lập trình", Description = "Chuyện lập trình - là chuyên mục mà một thằng coder viết về các vấn đề liên quan đến kỹ thuật, lập trình, những gì hắn đã học được trong quá trình cày cuốc của mình.", Order = 2};
                Category cate3 = new Category { Name = "Chuyện bên lề", Description = "Chuyện bên lề - là chuyên mục viết về mọi thứ liên quan đến cuộc sống của một thằng coder.", Order = 3 };
                Category cate4 = new Category { Name = "Chuyện cuộc sống", Description = "Những buồn vui trong cuộc sống của lập trình viên và những người làm trong ngành công nghệ.", Order = 4 };
                Category cate5 = new Category { Name = "Linux - ubuntu", Description = "Linux - ubuntu là chuyên mục mà một thằng coder viết về hệ điều hành hắn yêu thích, chia sẻ mọi thứ hắn biết về ubuntu và linux.", Order = 5 };
                Category cate6 = new Category { Name = "Hacking", Description = "Hack là việc lợi dụng những lỗ hổng bảo mật can thiệp một cách trái phép vào phần mềm, phần cứng, máy tính, hệ thống máy tính, mạng máy tính nhằm thay đổi các chức năng vốn có của nó.", Order = 6 };

                Tag tag1 = new Tag { Id = "lap-trinh-vien", Name = "Lập trình viên", Description = "Nghề lập trình viên, một nghề tưởng rằng công việc rất nhẹ nhàng, văn phòng đẹp giờ giấc thoải mái, nhưng không ai biết rằng đằng sau đó là một công việc rất vất vả, nhưng đam mê vẫn ở trong những lập trình viên trẻ, mong muốn tạo ra những phần mềm tiện ích. Tổng hợp các bài viết về lập trình viên hay nhất, để chúng ta hiểu rõ hơn về họ." };
                Tag tag2 = new Tag { Id = "nghe-lap-trinh-vien", Name = "Nghề lập trình viên", Description ="Các bài viết về ngành lập trình viên, ngành lập trình hiện đang là một ngành hot, lương cũng khá cao, các bài viết cập nhật các thông tin mới nhất." };
                Tag tag3 = new Tag { Id = "c#", Name = "C#", Description = "Mình chưa code android bao giờ, nhưng vẫn muốn có một app trên Google Play, điều này có vẻ không khả thi, mission imposible, đặc biệt là với một thằng mù java android như mình. Sau 10 tiếng lăn lộn vật vã cuối cùng cũng ra được ứng dụng đầu tiên" };
                Tag tag4 = new Tag { Id = "hacking", Name = "Hacking", Description = "Khi mới học lập trình, các bạn thường hỏi ngôn ngữ nào dễ học, dễ dàng tiếp cận nhất. Tuy nhiên mình nghĩ rằng việc lựa chọn ngôn ngữ lập trình nào là không quan trọng." };
                Tag tag5 = new Tag { Id = "tra-da", Name = "Trà đá", Description = "Jquery có lẽ không còn xa lạ với các bạn web developer, nó là một thư viện javascript giúp tạo nhiều hiệu ứng trên website nhanh với cú pháp code đơn giản hơn. Jquery được sử dụng rộng rãi và ngày càng mạnh mẽ bởi nhiều plugin mở rộng."};
                Tag tag6 = new Tag { Id = "dam-dao", Name = "Đàm đạo", Description = "Nghề lập trình viên, một nghề tưởng rằng công việc rất nhẹ nhàng, văn phòng đẹp giờ giấc thoải mái, nhưng không ai biết rằng đằng sau đó là một công việc rất vất vả, nhưng đam mê vẫn ở trong những lập trình viên trẻ, mong muốn tạo ra những phần mềm tiện ích. Tổng hợp các bài viết về lập trình viên hay nhất, để chúng ta hiểu rõ hơn về họ." };
                Tag tag7 = new Tag { Id = "system", Name = "System", Description = "Nghề lập trình viên, một nghề tưởng rằng công việc rất nhẹ nhàng, văn phòng đẹp giờ giấc thoải mái, nhưng không ai biết rằng đằng sau đó là một công việc rất vất vả, nhưng đam mê vẫn ở trong những lập trình viên trẻ, mong muốn tạo ra những phần mềm tiện ích. Tổng hợp các bài viết về lập trình viên hay nhất, để chúng ta hiểu rõ hơn về họ." };
                Tag tag8 = new Tag { Id = "ky-nang-mem", Name = "Kỹ năng mềm", Description = "Nghề lập trình viên, một nghề tưởng rằng công việc rất nhẹ nhàng, văn phòng đẹp giờ giấc thoải mái, nhưng không ai biết rằng đằng sau đó là một công việc rất vất vả, nhưng đam mê vẫn ở trong những lập trình viên trẻ, mong muốn tạo ra những phần mềm tiện ích. Tổng hợp các bài viết về lập trình viên hay nhất, để chúng ta hiểu rõ hơn về họ." };
                Tag tag9 = new Tag { Id = "huong-dan", Name = "Hướng dẫn", Description = "Nghề lập trình viên, một nghề tưởng rằng công việc rất nhẹ nhàng, văn phòng đẹp giờ giấc thoải mái, nhưng không ai biết rằng đằng sau đó là một công việc rất vất vả, nhưng đam mê vẫn ở trong những lập trình viên trẻ, mong muốn tạo ra những phần mềm tiện ích. Tổng hợp các bài viết về lập trình viên hay nhất, để chúng ta hiểu rõ hơn về họ." };

                Blog blog1 = new Blog
                {
                    Name = "Bình loạn về thuật toán in ra các số chẵn trong khoảng từ 1 đến 100",
                    Description = "<p>Hãy viết chương trình in ra các số chẵn trong khoảng từ 1 đến 100. Đây là một bài tập rất cơ bản với những người mới học lập trình, nó không hề khó, thậm chí dễ như ăn kẹo.</p>",
                    Image = "",
                    Content = @"<p>Hãy viết chương trình in ra các số chẵn trong khoảng từ 1 đến 100. Đây là một bài tập rất cơ bản với những người mới học lập trình, nó không hề khó, thậm chí dễ như ăn kẹo.</p><p>Đây là cách giải:</p><p><img src='images/code-tren-giay.jpg' alt='thuật toán in ra các số chẵn trong khoảng từ 1 đến 100' /></p><p>Có thể chương trình trên chỉ mang tính chất hài hước, mang nặng tinh thần chống đối. Sau khi đăng ảnh này lên facebook, đã có rất nhiều ý kiến chê bai kiểu như 'thằng trâu bò' hoặc 'Đề bài mà yêu cầu đến 10.000 thì viết đến sáng à?'. Tuy nhiên chúng ta sẽ phân tích theo một cách khác, dưới góc nhìn thực tế.</p><h2 id='nếu-đây-là-một-dự-án-thực-tế'>Nếu đây là một dự án thực tế</h2><p>Hãy tưởng tượng có một ông khách giàu sụ đến và bảo bạn rằng 'Viết cho tôi chương trình in ra các số chẵn trong khoảng từ 1 đến 100, hoàn thành trong 01 ngày, tôi sẽ trả cho anh 1000 đô'. Và tất nhiên, bạn không thể để lỡ kèo thơm như thế được.</p><h2 id='mình-cho-rằng-đây-là-một-lời-giải-tốt'>Mình cho rằng đây là một lời giải tốt</h2><p>Tại sao lại là lời giải tốt, mà không phải là lời giải đúng? Bởi vì trong trường học, nếu bạn đưa ra lời giải đúng bạn sẽ được điểm cao. Nhưng trong thực tế, cùng một vấn đề có rất nhiều cách để giải quyết, và không có phương án nào là đúng tuyệt đối cả, chỉ có phương án này tốt hơn phương án kia mà thôi.</p><h2 id='code-chỉ-là-phù-du-sản-phẩm-mới-là-quan-trọng'>Code chỉ là phù du, sản phẩm mới là quan trọng</h2><p>Có hàng tỉ cách để in ra được dãy số này, nhưng ai mà quan tâm cơ chứ? Cái mà người ta mong muốn là gì? Là chương trình in ra được dãy số trên, tất cả chỉ có vậy. Như blogger Hoàng code dạo đã viết '<a href='https://toidicodedao.com/2015/05/21/eo-ai-quan-tam-den-code-ban-viet-dau/'>Éo ai quan tâm đến code bạn viết đâu</a>'. Ông khách kia trả tiền để có được sản phẩm, chứ không phải code hay thuật toán gì cả.</p><h2 id='hiệu-năng-và-giá-trị'>Hiệu năng và giá trị</h2><p>Có thể cách giải trên có vẻ không thông minh cho lắm, nhưng nếu đây là một sản phẩm thực tế, tôi sẽ cho nó điểm 10, rõ ràng rằng chương trình đã làm tốt nhiệm vụ, tối ưu về tốc độ, ít (hoặc không có) lỗi phát sinh, sản phẩm dùng tốt đối với khách hàng, mang lại giá trị thực tế.</p><h2 id='đây-là-phương-án-phù-hợp'>Đây là phương án phù hợp</h2><p>Sau khi xem ảnh trên, một số bạn comment rằng: 'Thế nếu là 10.000 thì viết đến sáng à'</p><p>Không, nếu như bài toán là 10.000, chúng ta sẽ chọn phương án khác, các phương án đưa ra phải phù hợp với điều kiện và khả năng thực tế. Sử dụng những công nghệ và thuật toán phức tạp cho một vấn đề đơn giản là không thông minh cho lắm.</p><p>Mặc dù diện tích tờ giấy làm bài thi là có hạn, nhưng nó đủ để đáp ứng trong trường hợp này. Liên hệ với thực tiễn, chẳng việc gì phải sử dụng NoSql database cho một bảng chỉ có 100 record cả.</p><p>Về thời gian hoàn thành dự án, thời gian làm bài đủ để viết dãy số trên. Do đó, đây là một phương án tốt đảm bảo tiến độ trước deadline.</p><p>Hi vọng bài viết này đã cho bạn một cái nhìn mới, bạn nghĩ sao về bài thi này? Hãy để lại comment ở bên dưới.</p>",
                    Status = Status.Active,
                    Category = cate2,
                    DateCreated = DateTime.Now
                };
                Blog blog2 = new Blog
                {
                    Name = "Bình loạn về thuật toán",
                    Description = "<p>Hãy viết chương trình in ra các số chẵn trong khoảng từ 1 đến 100. Đây là một bài tập rất cơ bản với những người mới học lập trình, nó không hề khó, thậm chí dễ như ăn kẹo.</p>",
                    Image = "",
                    Content = @"Hãy viết chương trình in ra các số chẵn trong khoảng từ 1 đến 100. Đây là một bài tập Hãy viết chương trình in ra các số chẵn trong khoảng từ 1 đến 100. Đây là một bài tập Hãy viết chương trình in ra các số chẵn trong khoảng từ 1 đến 100. Đây là một bài tập Hãy viết chương trình in ra các số chẵn trong khoảng từ 1 đến 100. Đây là một bài tập Hãy viết chương trình in ra các số chẵn trong khoảng từ 1 đến 100. Đây là một bài tập Hãy viết chương trình in ra các số chẵn trong khoảng từ 1 đến 100. Đây là một bài tập ",
                    Status = Status.Active,
                    Category = cate1,
                    DateCreated = DateTime.Now
                };

                BlogTag blogTag1 = new BlogTag { Blog = blog1, Tag = tag1 };
                BlogTag blogTag11 = new BlogTag { Blog = blog1, Tag = tag2 };
                BlogTag blogTag2 = new BlogTag { Blog = blog2, Tag = tag1 };

                _context.Categories.AddRange(cate1, cate2, cate3, cate4, cate5, cate6);
                _context.Tags.AddRange(tag1, tag2, tag3, tag4, tag5, tag6, tag7, tag8, tag9);
                _context.Blogs.AddRange(blog1, blog2);
                _context.BlogTags.AddRange(blogTag1, blogTag11, blogTag2);

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
