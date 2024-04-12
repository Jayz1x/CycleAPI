using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
using CycleAPI.Domain;
using CycleAPI.infrastructure.Auth;
using CycleAPI.infrastructure;
using Microsoft.IdentityModel.Tokens;
using CycleAPI.Utils;
using CycleAPI.Application.Services;

namespace CycleAPI.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }

        //recuperar todos los productos de la base de datos
        [HttpGet]
        public ActionResult<List<Product>> Get()
        {
            try
            {
                var products = _service.GetAllProducts();
                return Ok(products);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error al obtener la lista de productos.", error = ex.Message });
            }
        }

        //recuperar el un solo producto usando la id de la base de datos
        [HttpGet("{id}")]
        public ActionResult<List<Product>> Get(int id)
        {
            try
            {
                var product = _service.GetProductById(id);
                if (product == null)
                {
                    return NotFound();
                }
                return Ok(product);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error al obtener el producto.", error = ex.Message });
            }
        }


        //agregar producto a la base de datos
        [ApiKey] //proteger la ruta usando masterkey
        [HttpPost]
        public ActionResult<Product> PostProduct([FromBody] Product product)
        {
            try
            {

                if (string.IsNullOrEmpty(product.Name) || string.IsNullOrEmpty(product.Category))
                {
                    return BadRequest("todos los campos son obligatorios");
                }

                if (product.Price <= 0)
                {
                    return BadRequest("el precio del producto no puede ser 0");
                }

                string base64Image = Base64Converter.ConvertImageToBase64(product.Image);

                if(string.IsNullOrEmpty(base64Image))
                {
                    return BadRequest("error al convertir imagen a base64");
                }

                var newProduct = new Product
                {
                    Name = product.Name,
                    Price = product.Price,
                    Category = product.Category,
                    Description = product.Description,
                    Image = base64Image,
                    State = product.State
                };

                _service.CreateProduct(newProduct);

                return Ok(newProduct);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error al crear el producto.", error = ex.Message });
            }
        }

        //editar los atributos del producto
        [ApiKey] // Proteger la ruta usando masterkey
        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, [FromBody] Product updatedProduct)
        {
            try
            {
                var existingProduct = _service.GetProductById(id);

                if (existingProduct == null)
                {
                    return NotFound("Producto no encontrado");
                }

                // Actualizar solo los campos que se enviaron en la solicitud
                if (!string.IsNullOrEmpty(updatedProduct.Name))
                {
                    existingProduct.Name = updatedProduct.Name;
                }

                if (updatedProduct.Price > 0)
                {
                    existingProduct.Price = updatedProduct.Price;
                }

                if (!string.IsNullOrEmpty(updatedProduct.Category))
                {
                    existingProduct.Category = updatedProduct.Category;
                }

                if (!string.IsNullOrEmpty(updatedProduct.Description))
                {
                    existingProduct.Description = updatedProduct.Description;
                }

                if (!string.IsNullOrEmpty(updatedProduct.Image))
                {
                    existingProduct.Image = updatedProduct.Image;
                }

                if (updatedProduct.State != null) // Si State es un tipo de dato nullable
                {
                    existingProduct.State = updatedProduct.State;
                }

                // Utilizar el servicio para actualizar el producto en la base de datos
                _service.UpdateProduct(existingProduct);

                // Devolver una respuesta de éxito
                return Ok("Producto actualizado correctamente");
            }
            catch (Exception ex)
            {
                // Devolver un código de estado 500 en caso de error y un mensaje con el detalle del error
                return StatusCode(500, new { message = "Error al actualizar el producto", error = ex.Message });
            }
        }

        //Borrar producto de la base de datos
        [ApiKey] //proteger la ruta usando masterkey
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            try
            {
                var product = _service.GetProductById(id);
                if (product == null)
                {
                    return NotFound();
                }

                _service.DeleteProduct(product);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error al eliminar el producto.", error = ex.Message });
            }
        }
    }
}
