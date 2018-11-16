using GolbEngine.Application.Services.Interfaces;
using GolbEngine.Application.ViewModels.Blog;
using GolbEngine.Data.Entities;
using GolbEngine.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using GolbEngine.Utilities.DTOs;

namespace GolbEngine.Application.Services.Implementation
{
    public class BlogService : IBlogService
    {
        private readonly IRepository<Blog, int> _blogRepository;
        private readonly IRepository<Tag, string> _tagRepository;
        private readonly IRepository<BlogTag, int> _blogTagRepository;
        private readonly IUnitOfWork _unitOfWork;

        public BlogService(IRepository<Blog, int> blogRepository,
            IRepository<BlogTag, int> blogTagRepository,
            IRepository<Tag, string> tagRepository,
            IUnitOfWork unitOfWork)
        {
            _blogRepository = blogRepository;
            _blogTagRepository = blogTagRepository;
            _tagRepository = tagRepository;
            _unitOfWork = unitOfWork;
        }

        public BlogViewModel Add(BlogViewModel blog)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<BlogViewModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public PagedResult<BlogViewModel> GetAllPaging(string keyword, int pageSize, int page)
        {
            throw new NotImplementedException();
        }

        public BlogViewModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<BlogViewModel> GetLastest(int top)
        {
            throw new NotImplementedException();
        }

        public List<BlogViewModel> GetList(string keyword)
        {
            throw new NotImplementedException();
        }

        public List<BlogViewModel> GetListByTag(string tagId, int page, int pagesize, out int totalRow)
        {
            throw new NotImplementedException();
        }

        public List<BlogViewModel> GetListPaging(int page, int pageSize, string sort, out int totalRow)
        {
            throw new NotImplementedException();
        }

        public List<TagViewModel> GetListTag(string searchText)
        {
            throw new NotImplementedException();
        }

        public List<TagViewModel> GetListTagById(int id)
        {
            throw new NotImplementedException();
        }

        public List<BlogViewModel> GetReatedBlogs(int id, int top)
        {
            throw new NotImplementedException();
        }

        public TagViewModel GetTag(string tagId)
        {
            throw new NotImplementedException();
        }

        public void IncreaseView(int id)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public List<BlogViewModel> Search(string keyword, int page, int pageSize, string sort, out int totalRow)
        {
            throw new NotImplementedException();
        }

        public void Update(BlogViewModel blog)
        {
            throw new NotImplementedException();
        }
    }
}
