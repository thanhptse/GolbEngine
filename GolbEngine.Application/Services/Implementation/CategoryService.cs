using AutoMapper.QueryableExtensions;
using GolbEngine.Application.Services.Interfaces;
using GolbEngine.Application.ViewModels.Blog;
using GolbEngine.Data.Entities;
using GolbEngine.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GolbEngine.Application.Services.Implementation
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository<Category, int> _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(IRepository<Category, int> categoryRepository,
            IUnitOfWork unitOfWork)
        {
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
        }

        public List<CategoryViewModel> GetAll()
        {
            return _categoryRepository.FindAll().OrderBy(x => x.OwnerId)
                 .ProjectTo<CategoryViewModel>().ToList();
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }
    }
}
