using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CycleAPI.Domain;
using Microsoft.AspNetCore.Mvc;
using CycleAPI.Application.Repositories;
using CycleAPI.infrastructure.dbContext;

namespace CycleAPI.infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDbContext _productDbContext;

        public ProductRepository(ProductDbContext productDbContext)
        {
            _productDbContext = productDbContext;
        }

        public Product CreateProduct(Product product)
        {
            _productDbContext.Products.Add(product);
            _productDbContext.SaveChanges();
            return product;
        }

        public Product DeleteProduct(Product productID)
        {
            _productDbContext.Products.Remove(productID);
            _productDbContext.SaveChanges();
            return productID;
        }

        public List<Product> GetAllProducts()
        {
            return _productDbContext.Products.ToList();
        }


        public Product GetProductById(int ProductID)
        {
            return _productDbContext.Products.FirstOrDefault(p => p.Id == ProductID);
        }

        public Product UpdateProduct(Product updatedProduct)
        {
            var existingProduct = _productDbContext.Products.Find(updatedProduct.Id);
            if (existingProduct == null)
            {
                throw new Exception("Producto no encontrado");
            }

            existingProduct.Name = updatedProduct.Name;
            existingProduct.Price = updatedProduct.Price;
            existingProduct.Category = updatedProduct.Category;
            existingProduct.Description = updatedProduct.Description;
            existingProduct.Image = updatedProduct.Image;
            existingProduct.State = updatedProduct.State;

            _productDbContext.SaveChanges();
            return existingProduct;
        }
    }
}
