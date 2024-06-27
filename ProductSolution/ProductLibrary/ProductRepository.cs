using System.Collections.Generic;
using System.Linq;

namespace ProductLibrary
{
    public class ProductRepository
    {
        private List<Product> _products = new List<Product>();

        public void CreateProduct(Product product)
        {
            _products.Add(product);
        }

        public Product GetProduct(int id)
        {
            return _products.FirstOrDefault(p => p.Id == id);
        }

        public void UpdateProduct(Product product)
        {
            var existingProduct = _products.FirstOrDefault(p => p.Id == product.Id);
            if (existingProduct != null)
            {
                existingProduct.Name = product.Name;
                existingProduct.Price = product.Price;
            }
        }

        public void DeleteProduct(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                _products.Remove(product);
            }
        }

    }
}