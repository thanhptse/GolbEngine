using GolbEngine.Application.ViewModels.Blog;
using System;
using System.Collections.Generic;
using System.Text;

namespace GolbEngine.Application.Services.Interfaces
{
    public interface ITagService
    {
        List<TagViewModel> GetAll();

        TagViewModel GetById(string id);

        void Save();
    }
}
