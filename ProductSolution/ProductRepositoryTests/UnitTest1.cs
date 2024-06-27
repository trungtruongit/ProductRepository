using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductLibrary;
using System.Linq;

namespace ProductRepositoryTests
{
    [TestClass]
    public class ProductRepositoryTests
    {
        private ProductRepository _repository;

        [TestInitialize]
        public void Setup()
        {
            _repository = new ProductRepository();
        }

        [TestMethod]
        public void CreateProduct_ShouldAddProduct()
        {
            var product = new Product { Id = 1, Name = "Product 1", Price = 10.0m };
            _repository.CreateProduct(product);

            var result = _repository.GetProduct(1);
            Assert.IsNotNull(result);
            Assert.AreEqual("Product 1", result.Name);
        }

        [TestMethod]
        public void GetProduct_ShouldReturnProduct()
        {
            var product = new Product { Id = 1, Name = "Product 1", Price = 10.0m };
            _repository.CreateProduct(product);

            var result = _repository.GetProduct(1);
            Assert.IsNotNull(result);
            Assert.AreEqual("Product 1", result.Name);
        }

        [TestMethod]
        public void UpdateProduct_ShouldModifyProduct()
        {
            var product = new Product { Id = 1, Name = "Product 1", Price = 10.0m };
            _repository.CreateProduct(product);

            product.Name = "Updated Product";
            product.Price = 20.0m;
            _repository.UpdateProduct(product);

            var result = _repository.GetProduct(1);
            Assert.IsNotNull(result);
            Assert.AreEqual("Updated Product", result.Name);
            Assert.AreEqual(20.0m, result.Price);
        }

        [TestMethod]
        public void DeleteProduct_ShouldRemoveProduct()
        {
            var product = new Product { Id = 1, Name = "Product 1", Price = 10.0m };
            _repository.CreateProduct(product);

            _repository.DeleteProduct(1);

            var result = _repository.GetProduct(1);
            Assert.IsNull(result);
        }
    }
}