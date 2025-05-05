using Assetwiz_Contact.BusinessObjects;
using Assetwiz_Contact.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assetwiz_Contact.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductTransactionController : ControllerBase
    {
        public readonly ProductTransactionBusinessObject _productTransactionBO;

        public ProductTransactionController(ProductTransactionBusinessObject productTransactionBO)
        {
            _productTransactionBO = productTransactionBO;
        }

        [HttpGet("GetAllProductTransaction")]
        public async Task<IActionResult> GetAllProductTransaction()
        {
            var productTransactions = await _productTransactionBO.GetAllProductTransactionsAsync();
            if (productTransactions == null || !productTransactions.Any())
            {
                return NotFound("No product transactions found.");
            }
            return Ok(new
            {
                message = "Product Transactions Found Successfully.",
                data = productTransactions
            });
        }

        [HttpGet("GetProductTransactionById/{id}")]
        public async Task<IActionResult> GetProductTransactionById(long id)
        {
            var productTransaction = await _productTransactionBO.GetProductTransactionByIdAsync(id);
            if (productTransaction == null)
            {
                return NotFound("No product transactions found.");
            }
            return Ok(new
            {
                message = "Product Transactions Found Successfully.",
                data = productTransaction
            });
        }

        [HttpPost("AddProductTransaction")]
        public async Task<IActionResult> AddProductTransaction([FromBody] ProductTransactionViewModel productTransaction)
        {
            var createdProductTransaction = await _productTransactionBO.AddProductTransactionAsync(productTransaction);
            if (createdProductTransaction == null)
            {
                return BadRequest("Error occur During Product Transaction add.");
            }
            return CreatedAtAction(nameof(GetProductTransactionById), new { id = createdProductTransaction.ProductID }, productTransaction);
        }

        [HttpPut("UpdateProductTransaction/{id}")]
        public async Task<IActionResult> UpdateProductTransaction(long id, [FromBody] ProductTransactionViewModel updatedProductTransaction)
        {
            var productTransaction = await _productTransactionBO.UpdateProductTransactionAsync(id, updatedProductTransaction);
            if (productTransaction == null)
            {
                return NotFound("No product transactions found.");
            }
            return Ok(new
            {
                message = "Product Transaction Updated Successfully.",
                data = productTransaction
            });
        }

        [HttpDelete("DeleteProductTransaction/{id}")]
        public async Task<IActionResult> DeleteProductTransaction(long id)
        {
            var isDeleted = await _productTransactionBO.DeleteProductTransactionAsync(id);
            if (!isDeleted)
            {
                return NotFound("No product transactions found.");
            }
            return Ok(new
            {
                message = "Product Transaction Deleted Successfully."
            });
        }
    }
}
