using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CycleAPI.Domain;

namespace CycleAPI.Application.Repositories
{
    public interface IProductRepository
    {
        List<Product> GetAllProducts();
        Product GetProductById(int productID);
        Product CreateProduct(Product product);

        Product UpdateProduct(Product productID);

        Product DeleteProduct(Product productID);
    }
}
