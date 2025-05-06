using Assetwiz_Contact.BusinessObjects;
using Assetwiz_Contact.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace Assetwiz_Contact.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductPartsController : ControllerBase
    {
        private readonly ProductPartsBusinessObject _productPartsBO;

        public ProductPartsController(ProductPartsBusinessObject productPartsBO)
        {
            _productPartsBO = productPartsBO;
        }

        [HttpGet("GetAllProductParts")]
        public async Task<IActionResult> GetAllProductParts()
        {
            var parts = await _productPartsBO.GetAllProductPartsAsync();
            if (parts == null || !parts.Any())
            {
                return NotFound("No product parts found.");
            }
            return Ok(parts);
        }

        [HttpGet("GetProductPartById/{id}")]
        public async Task<IActionResult> GetProductPartById(long id)
        {
            var part = await _productPartsBO.GetProductPartByIdAsync(id);
            if (part == null)
            {
                return NotFound($"Product part with ID {id} not found.");
            }
            return Ok(part);
        }

        [HttpPost("AddProductPart")]
        public async Task<IActionResult> AddProductPart([FromBody] ProductPartsViewModel productPart)
        {
            var createdPart = await _productPartsBO.AddProductPartAsync(productPart);
            if (createdPart == null)
            {
                return BadRequest("Error creating product part.");
            }
            return CreatedAtAction(nameof(GetProductPartById), new { id = createdPart.ProductPartsID }, createdPart);
        }

        [HttpPut("UpdateProductPart/{id}")]
        public async Task<IActionResult> UpdateProductPart(long id, [FromBody] ProductPartsViewModel updatedPart)
        {
            var part = await _productPartsBO.UpdateProductPartAsync(id, updatedPart);
            if (part == null)
            {
                return NotFound($"Product part with ID {id} not found.");
            }
            return Ok(new
            {
                message = "Product part updated successfully.",
                Data = part
            });
        }

        [HttpDelete("DeleteProductPart/{id}")]
        public async Task<IActionResult> DeleteProductPart(long id)
        {
            var deleted = await _productPartsBO.DeleteProductPartAsync(id);
            if (!deleted)
            {
                return NotFound($"Product part with ID {id} not found.");
            }
            return Ok(new
            {
                message = "Product part deleted successfully.",
                status = deleted
            });
        }
    }
}
