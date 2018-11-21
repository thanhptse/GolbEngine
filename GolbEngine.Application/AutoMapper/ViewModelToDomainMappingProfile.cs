using AutoMapper;
using GolbEngine.Application.ViewModels.Blog;
using GolbEngine.Application.ViewModels.System;
using GolbEngine.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GolbEngine.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<BlogViewModel, Blog>();
            CreateMap<CategoryViewModel, Category>();
        }
    }
}
