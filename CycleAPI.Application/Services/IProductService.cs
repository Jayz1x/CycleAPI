using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CycleAPI.Domain;

namespace CycleAPI.Application.Services
{
    //caso de uso para el CRUD
    public interface IProductService
    {
        List<Product> GetAllProducts();
        Product GetProductById(int ProductID);
        Product CreateProduct(Product product);

        Product UpdateProduct(Product productID);

        Product DeleteProduct(Product productID);

    }
}
