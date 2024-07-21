using Bogus;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestDemo.Interfaces;
using UnitTestDemo.Models;

namespace UnitTestDemo.Tests
{
    public class ProductRepositoryTests
    {
        private readonly Mock<IRepository<Product>> _mockRepository;
        private readonly List<Product> _fakeProducts;

        public ProductRepositoryTests()
        {
            // יצירת רשימה מדומה של מוצרים באופן אקראי באמצעות Bogus
            _fakeProducts = new Faker<Product>()
                .RuleFor(p => p.Id, f => f.IndexFaker + 1)
                .RuleFor(p => p.Name, f => f.Commerce.ProductName())
                .Generate(10); // יצירת 10 מוצרים אקראיים

            // יצירת Mock עבור הריפוזיטורי
            _mockRepository = new Mock<IRepository<Product>>();

            // הגדרת התנהגות Mock: כאשר קוראים לפונקציית GetAll, החזר את רשימת המוצרים המדומה
            _mockRepository.Setup(repo => repo.GetAll()).Returns(_fakeProducts);
        }

        [Fact]
        public void GetAll_ReturnsAllProducts()
        {
            // Act
            var products = _mockRepository.Object.GetAll();

            // Assert
            Assert.Equal(10, products.Count());
            foreach (var product in _fakeProducts)
            {
                Assert.Contains(products, p => p.Name == product.Name);
            }
        }

        [Fact]
        public void GetAll_VerifyGetAllCalledOnce()
        {
            // Act
            var products = _mockRepository.Object.GetAll();

            // Assert
            _mockRepository.Verify(repo => repo.GetAll(), Times.Once);
        }
    }
}
