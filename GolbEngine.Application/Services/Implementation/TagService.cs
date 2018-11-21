using AutoMapper;
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
    public class TagService : ITagService
    {
        private readonly IRepository<Tag, string> _tagRepository;
        private readonly IUnitOfWork _unitOfWork;

        public TagService(IRepository<Tag, string> tagRepository,
            IUnitOfWork unitOfWork)
        {
            _tagRepository = tagRepository;
            _unitOfWork = unitOfWork;
        }

        public List<TagViewModel> GetAll()
        {
            return _tagRepository.FindAll().ProjectTo<TagViewModel>().ToList();
        }

        public TagViewModel GetById(string id)
        {
            return Mapper.Map<Tag, TagViewModel>(_tagRepository.FindById(id));
        }


        public void Save()
        {
            _unitOfWork.Commit();
        }
    }
}
