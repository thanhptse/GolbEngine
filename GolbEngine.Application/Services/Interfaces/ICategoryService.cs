﻿using GolbEngine.Application.ViewModels.Blog;
using System;
using System.Collections.Generic;
using System.Text;

namespace GolbEngine.Application.Services.Interfaces
{
    public interface ICategoryService
    {
        List<CategoryViewModel> GetAll();

        CategoryViewModel GetById(int id);

        void Save();
    }
}
