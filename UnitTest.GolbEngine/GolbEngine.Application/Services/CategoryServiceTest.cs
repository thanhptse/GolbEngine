using GolbEngine.Application.Services.Interfaces;
using GolbEngine.Data.Entities;
using GolbEngine.Infrastructure.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using GolbEngine.Application.Services.Implementation;
using AutoMapper;
using GolbEngine.Application.AutoMapper;

namespace UnitTest.GolbEngine.GolbEngine.Application.Services
{
    [TestClass]
    public class CategoryServiceTest
    {
        private readonly Mock<IRepository<Category, int>> _categoryRepository = new Mock<IRepository<Category, int>>();
        private readonly Mock<IUnitOfWork> _unitOfWork = new Mock<IUnitOfWork>();

        private ICategoryService categoryService;

        [TestInitialize]
        public void Init()
        {
            Mapper.Initialize(c =>
            {
                c.AddProfile<DomainToViewModelMappingProfile>();
                c.AddProfile<ViewModelToDomainMappingProfile>();
            });
        }

        [TestMethod]
        public void GetAll_ShouldReturnData_OrderByOrderFieldAsc()
        {
            Mapper.Initialize(c =>
            {
                c.AddProfile<DomainToViewModelMappingProfile>();
                c.AddProfile<ViewModelToDomainMappingProfile>();
            });
            // arrange
            var categories = new List<Category>
                            {
                                new Category{Order = 6},
                                new Category{Order = 2}
                            };

            _categoryRepository.Setup(x => x.FindAll())
                .Returns(categories.AsQueryable());
            
            categoryService = new CategoryService(_categoryRepository.Object, _unitOfWork.Object);

            // action
            var result = categoryService.GetAll();

            // assert
            Assert.AreEqual(2, result[0].Order);
            Assert.AreEqual(6, result[0].Order);
        }
    }
}
