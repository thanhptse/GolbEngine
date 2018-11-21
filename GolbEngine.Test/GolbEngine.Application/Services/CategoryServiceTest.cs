using GolbEngine.Data.Entities;
using GolbEngine.Infrastructure.Interfaces;
using Moq;
using NUnit.Framework;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using GolbEngine.Application.Services.Interfaces;
using GolbEngine.Application.Services.Implementation;

namespace GolbEngine.ZTest.GolbEngine.Application.Services
{
    [TestFixture]
    public class CategoryServiceTest
    {
        private Mock<IRepository<Category, int>> _categoryRepository = new Mock<IRepository<Category, int>>();
        private Mock<IUnitOfWork> _unitOfWork = new Mock<IUnitOfWork>();
        private ICategoryService categoryService;

        [Test]
        public void GetAll_ShouldReturnData_OrderByOrder()
        {
            // arrange
            var blogs = new List<Category>
                        {
                                new Category{Order = 6},
                                new Category{Order = 2}
                        };
            _categoryRepository.Setup(x => x.FindAll())
                .Returns(blogs.AsQueryable());

            categoryService = new CategoryService(_categoryRepository.Object, _unitOfWork.Object);

            // action
            var result = categoryService.GetAll();

            // assert
            Assert.AreEqual(2, result[0].Order);
            Assert.AreEqual(6, result[0].Order);
        }
    }
}
