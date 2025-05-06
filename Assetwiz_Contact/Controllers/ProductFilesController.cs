using Assetwiz_Contact.BusinessObjects;
using Assetwiz_Contact.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace Assetwiz_Contact.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductFilesController : ControllerBase
    {
        private readonly ProductFilesBusinessObject _productFilesBO;

        public ProductFilesController(ProductFilesBusinessObject productFilesBO)
        {
            _productFilesBO = productFilesBO;
        }

        [HttpGet("GetAllProductFiles")]
        public async Task<IActionResult> GetAllProductFiles()
        {
            var files = await _productFilesBO.GetAllProductFilesAsync();
            if (files == null || !files.Any())
            {
                return NotFound("No product files found.");
            }
            return Ok(files);
        }

        [HttpGet("GetProductFileById/{id}")]
        public async Task<IActionResult> GetProductFileById(long id)
        {
            var file = await _productFilesBO.GetProductFileByIdAsync(id);
            if (file == null)
            {
                return NotFound($"Product file with ID {id} not found.");
            }
            return Ok(file);
        }

        [HttpPost("AddProductFile")]
        public async Task<IActionResult> AddProductFile([FromBody] ProductFilesViewModel productFile)
        {
            var createdFile = await _productFilesBO.AddProductFileAsync(productFile);
            if (createdFile == null)
            {
                return BadRequest("Error creating product file.");
            }
            return CreatedAtAction(nameof(GetProductFileById), new { id = createdFile.ProductFilesID }, createdFile);
        }

        [HttpPut("UpdateProductFile/{id}")]
        public async Task<IActionResult> UpdateProductFile(long id, [FromBody] ProductFilesViewModel updatedFile)
        {
            var file = await _productFilesBO.UpdateProductFileAsync(id, updatedFile);
            if (file == null)
            {
                return NotFound($"Product file with ID {id} not found.");
            }
            return Ok(new
            {
                message = "Product file updated successfully.",
                Data = file
            });
        }

        [HttpDelete("DeleteProductFile/{id}")]
        public async Task<IActionResult> DeleteProductFile(long id)
        {
            var deleted = await _productFilesBO.DeleteProductFileAsync(id);
            if (!deleted)
            {
                return NotFound($"Product file with ID {id} not found.");
            }
            return Ok(new
            {
                message = "Product file deleted successfully.",
                status = deleted
            });
        }
    }
}
