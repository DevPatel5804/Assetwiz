using Assetwiz_Contact.BusinessObjects;
using Assetwiz_Contact.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assetwiz_Contact.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductsBusinessObject _productBO;

        public ProductsController(ProductsBusinessObject productBO)
        {
            _productBO = productBO;
        }

        [HttpGet("GetAllProducts")]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _productBO.GetAllProductsAsync();
            if (products == null || !products.Any())
            {
                return NotFound("No products found.");
            }
            return Ok(products);
        }

        [HttpGet("GetProductById/{id}")]
        public async Task<IActionResult> GetProductById(long id)
        {
            var product = await _productBO.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound($"Product with ID {id} not found.");
            }
            return Ok(product);
        }

        [HttpPost("AddProduct")]
        public async Task<IActionResult> AddProduct([FromBody] ProductsViewModel product)
        {
            var createdProduct = await _productBO.AddProductAsync(product);
            if (createdProduct == null)
            {
                return BadRequest("Error creating product.");
            }
            return CreatedAtAction(nameof(GetProductById), new { id = createdProduct.ProductID }, createdProduct);
        }

        [HttpPut("UpdateProduct/{id}")]
        public async Task<IActionResult> UpdateProduct(long id, [FromBody] ProductsViewModel updatedProduct)
        {
            var product = await _productBO.UpdateProductAsync(id, updatedProduct);
            if (product == null)
            {
                return NotFound($"Product with ID {id} not found.");
            }
            return Ok(new
            {
                message = "Product Updated Successfully.",
                Data = product
            });
        }

        [HttpDelete("DeleteProduct/{id}")]
        public async Task<IActionResult> DeleteProduct(long id)
        {
            var deleted = await _productBO.DeleteProductAsync(id);
            if (!deleted)
            {
                return NotFound($"Product with ID {id} not found.");
            }
            return Ok(new
            {
                message = "Product Deleted Successfully",
                status = deleted
            });
        }
    }
}
