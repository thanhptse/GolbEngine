using AutoMapper;
using GolbEngine.Application.ViewModels.Blog;
using GolbEngine.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GolbEngine.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Blog, BlogViewModel>();
            CreateMap<Category, CategoryViewModel>();
            CreateMap<Tag, TagViewModel>();
        }
    }
}
