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
    [Route("api/[controller]")]
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

                return Ok(newProduct);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error al crear el producto.", error = ex.Message });
            }
        }

        //editar los atributos del producto
        [ApiKey] //proteger la ruta usando masterkey
        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, Product product)
        {
            try
            {
                var existingProduct = _service.GetProductById(id);

                if (existingProduct == null)
                {
                    return NotFound("Producto no encontrado");
                }

                return Ok(existingProduct);
            }catch (Exception ex)
            {
                return StatusCode(500, new { ex.Message });
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
