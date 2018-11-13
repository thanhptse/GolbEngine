using AutoMapper;
using GolbEngine.Application.ViewModels.Blog;
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
            CreateMap<BlogViewModel, Blog>().ConstructUsing(x => new Blog(x.Title, x.Content, x.Status, x.CategoryId));
        }
    }
}
