using GolbEngine.Application.ViewModels.Blog;
using GolbEngine.Utilities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace GolbEngine.Application.Services.Interfaces
{
    public interface IBlogService
    {
        BlogViewModel Add(BlogViewModel blog);

        void Update(BlogViewModel blog);

        void Delete(int id);

        List<BlogViewModel> GetAll();

        List<BlogViewModel> GetHotBlog(int top);

        PagedResult<BlogViewModel> GetAllPaging(int? categoryId, string keyword, int pageSize, int page);

        List<BlogViewModel> GetLastest(int top);

        List<BlogViewModel> GetListPaging(int page, int pageSize, string sort, out int totalRow);

        List<BlogViewModel> Search(string keyword, int page, int pageSize, string sort, out int totalRow);

        List<BlogViewModel> GetList(string keyword);

        List<BlogViewModel> GetReatedBlogs(int top);

        BlogViewModel GetById(int id);

        void Save();

        List<BlogViewModel> GetListByTagId(string tagId);

        TagViewModel GetTag(string tagId);

        void IncreaseView(int id);

        List<BlogViewModel> GetListByTag(string tagId, int page, int pagesize, out int totalRow);

        List<TagViewModel> GetListTag(string searchText);

        List<TagViewModel> GetBlogTags(int blogid);

        List<BlogViewModel> GetBlogByCategoryId(int categoryId);

        List<BlogViewModel> GetGoodPost();
    }
}
