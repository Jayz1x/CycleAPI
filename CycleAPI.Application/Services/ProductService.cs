using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using CycleAPI.Application.Repositories;
using CycleAPI.Domain;


namespace CycleAPI.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        //constructor para dependency injection
        public ProductService(IProductRepository ProductRepository)
        {
            _productRepository = ProductRepository;
        }

        public Product CreateProduct(Product product)
        {
            _productRepository.CreateProduct(product);

            return product;
        }

        public List<Product> GetAllProducts()
        {
            var products = _productRepository.GetAllProducts();

            return products;
        }

        public Product GetProductById(int id)
        {
            var product = _productRepository.GetProductById(id);

            return product;
        }


        public Product UpdateProduct(Product productID)
        {
            _productRepository.UpdateProduct(productID);

            return productID;
        }

        public Product DeleteProduct(Product productID)
        {
            _productRepository.DeleteProduct(productID);

            return productID;
        }


    }
}