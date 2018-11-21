using GolbEngine.Application.Services.Interfaces;
using GolbEngine.Application.ViewModels.Blog;
using GolbEngine.Data.Entities;
using GolbEngine.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using GolbEngine.Utilities.DTOs;
using AutoMapper;
using GolbEngine.Utilities.Helpers;
using System.Linq;
using AutoMapper.QueryableExtensions;
using GolbEngine.Data.Enums;

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

        public BlogViewModel Add(BlogViewModel blogVm)
        {
            var blog = Mapper.Map<BlogViewModel, Blog>(blogVm);
          
            if (!string.IsNullOrEmpty(blog.Tags))
            {
                var tags = blog.Tags.Split(',');
                foreach (string t in tags)
                {
                    var tagId = TextHelper.ToUnsignString(t);
                    if (!_tagRepository.FindAll(x => x.Id == tagId).Any())
                    {
                        Tag tag = new Tag
                        {
                            Id = tagId,
                            Name = t,
                        };
                        _tagRepository.Add(tag);
                    }

                    var blogTag = new BlogTag { TagId = tagId };
                    blog.BlogTags.Add(blogTag);        
                }
            }
            
            _blogRepository.Add(blog);
            
            return blogVm;
        }

        public void Delete(int id)
        {
            _blogRepository.Remove(id);
        }

        public List<BlogViewModel> GetAll()
        {
            return _blogRepository.FindAll(c => c.BlogTags)
                .ProjectTo<BlogViewModel>().OrderByDescending(x => x.DateCreated).ToList();
        }

        public List<BlogViewModel> GetGoodPost()
        {
            return _blogRepository.FindAll(x => x.HotFlag == true).ProjectTo<BlogViewModel>().OrderByDescending(x => x.ViewCount).ToList();
        }

        public List<BlogViewModel> GetBlogByCategoryId(int categoryId)
        {
            return _blogRepository.FindAll(x => x.CategoryId == categoryId).OrderByDescending(x => x.DateCreated).ProjectTo<BlogViewModel>().ToList();
        }

        public PagedResult<BlogViewModel> GetAllPaging(int? categoryId, string keyword, int page, int pageSize)
        {
            var query = _blogRepository.FindAll();
            if (!string.IsNullOrEmpty(keyword))
                query = query.Where(x => x.Name.Contains(keyword));

            if (categoryId.HasValue)
                query = query.Where(x => x.CategoryId == categoryId.Value);

            int totalRow = query.Count();
            var data = query.OrderByDescending(x => x.DateCreated)
                .Skip((page - 1) * pageSize)
                .Take(pageSize);

            var paginationSet = new PagedResult<BlogViewModel>()
            {
                Results = data.ProjectTo<BlogViewModel>().ToList(),
                CurrentPage = page,
                RowCount = totalRow,
                PageSize = pageSize,
            };

            return paginationSet;
        }

        public BlogViewModel GetById(int id)
        {
            return Mapper.Map<Blog, BlogViewModel>(_blogRepository.FindById(id));
        }

        public List<BlogViewModel> GetLastest(int top)
        {
            return _blogRepository.FindAll(x => x.Status == Status.Active).OrderByDescending(x => x.DateCreated)
                .Take(top).ProjectTo<BlogViewModel>().ToList();
        }

        public List<BlogViewModel> GetList(string keyword)
        {
            var query = !string.IsNullOrEmpty(keyword) ?
                _blogRepository.FindAll(x => x.Name.Contains(keyword)).ProjectTo<BlogViewModel>()
                : _blogRepository.FindAll().ProjectTo<BlogViewModel>();
            return query.ToList();
        }

        public List<BlogViewModel> GetHotBlog(int top)
        {
            return _blogRepository.FindAll(x => x.Status == Status.Active && x.HotFlag == true)
                .OrderByDescending(x => x.DateCreated)
                .Take(top)
                .ProjectTo<BlogViewModel>()
                .ToList();
        }

        public List<BlogViewModel> GetListByTag(string tagId, int page, int pageSize, out int totalRow)
        {
            var query = from p in _blogRepository.FindAll()
                        join pt in _blogTagRepository.FindAll()
                        on p.Id equals pt.BlogId
                        where pt.TagId == tagId && p.Status == Status.Active
                        orderby p.DateCreated descending
                        select p;

            totalRow = query.Count();

            query = query.Skip((page - 1) * pageSize).Take(pageSize);

            var model = query
                .ProjectTo<BlogViewModel>();
            return model.ToList();
        }

        public List<TagViewModel> GetBlogTags(int blogid)
        {
            var tags = _tagRepository.FindAll();
            var blogTags = _blogTagRepository.FindAll();

            var query = from t in tags
                        join pt in blogTags
                        on t.Id equals pt.TagId
                        where pt.BlogId == blogid
                        select new TagViewModel()
                        {
                            Id = t.Id,
                            Name = t.Name
                        };
            return query.ToList();
        }

        public List<BlogViewModel> GetListPaging(int page, int pageSize, string sort, out int totalRow)
        {
            var query = _blogRepository.FindAll(x => x.Status == Status.Active);

            switch (sort)
            {
                case "popular":
                    query = query.OrderByDescending(x => x.ViewCount);
                    break;

                default:
                    query = query.OrderByDescending(x => x.DateCreated);
                    break;
            }

            totalRow = query.Count();

            return query.Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ProjectTo<BlogViewModel>().ToList();
        }

        public List<TagViewModel> GetListTag(string searchText)
        {
            return _tagRepository.FindAll(x => searchText.Contains(x.Name)).ProjectTo<TagViewModel>().ToList();
        }

        public List<BlogViewModel> GetListByTagId(string tagId)
        {
            var query = from p in _blogRepository.FindAll()
                        join pt in _blogTagRepository.FindAll()
                        on p.Id equals pt.BlogId
                        where pt.TagId == tagId && p.Status == Status.Active
                        orderby p.DateCreated descending
                        select p;

            var model = query.ProjectTo<BlogViewModel>();
            return model.ToList();
        }

        public List<BlogViewModel> GetReatedBlogs(int top)
        {
            return _blogRepository.FindAll(x => x.Status == Status.Active).OrderByDescending(x => x.DateCreated)
                .Take(top).ProjectTo<BlogViewModel>().ToList();
        }

        public TagViewModel GetTag(string tagId)
        {
            throw new NotImplementedException();
        }

        public void IncreaseView(int id)
        {
            var product = _blogRepository.FindById(id);
            if (product.ViewCount.HasValue)
                product.ViewCount += 1;
            else
                product.ViewCount = 1;
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public List<BlogViewModel> Search(string keyword, int page, int pageSize, string sort, out int totalRow)
        {
            var query = _blogRepository.FindAll(x => x.Status == Status.Active
            && x.Name.Contains(keyword));

            switch (sort)
            {
                case "popular":
                    query = query.OrderByDescending(x => x.ViewCount);
                    break;

                default:
                    query = query.OrderByDescending(x => x.DateCreated);
                    break;
            }

            totalRow = query.Count();

            return query.Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ProjectTo<BlogViewModel>()
                .ToList();
        }

        public void Update(BlogViewModel blog)
        {
            Blog tmpBlog = _blogRepository.FindById(blog.Id);
            tmpBlog.HotFlag = blog.HotFlag;
            tmpBlog.Name = blog.Name;
            tmpBlog.Image = blog.Image;
            tmpBlog.Description = blog.Description;
            tmpBlog.Content = blog.Content;
            tmpBlog.Status = blog.Status;
            tmpBlog.CategoryId = blog.CategoryId;
            tmpBlog.Tags = blog.Tags;

            _blogRepository.Update(tmpBlog);
            if (!string.IsNullOrEmpty(blog.Tags))
            {
                string[] tags = blog.Tags.Split(',');
                foreach (string t in tags)
                {
                    var tagId = TextHelper.ToUnsignString(t);
                    if (!_tagRepository.FindAll(x => x.Id == tagId).Any())
                    {
                        Tag tag = new Tag
                        {
                            Id = tagId,
                            Name = t,
                        };
                        _tagRepository.Add(tag);
                    }
                    _blogTagRepository.RemoveMultiple(_blogTagRepository.FindAll(x => x.Id == blog.Id).ToList());
                    BlogTag blogTag = new BlogTag
                    {
                        BlogId = blog.Id,
                        TagId = tagId
                    };
                    _blogTagRepository.Add(blogTag);
                }
            }
        }
    }
}
