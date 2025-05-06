//using Assetwiz_Contact.BusinessObjects;
//using Assetwiz_Contact.ViewModels;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace Assetwiz_Contact.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class GroupProductsController : ControllerBase
//    {
//        private readonly GroupProductsBusinessObject _groupProductsBO;

//        public GroupProductsController(GroupProductsBusinessObject groupProductsBO)
//        {
//            _groupProductsBO = groupProductsBO;
//        }

//        [HttpGet("GetAllGroupProducts")]
//        public async Task<IActionResult> GetAllGroupProducts()
//        {
//            var items = await _groupProductsBO.GetAllGroupProductsAsync();
//            if (items == null || !items.Any())
//            {
//                return NotFound("No group products found.");
//            }
//            return Ok(items);
//        }

//        [HttpGet("GetGroupProductById/{id}")]
//        public async Task<IActionResult> GetGroupProductById(long id)
//        {
//            var item = await _groupProductsBO.GetGroupProductByIdAsync(id);
//            if (item == null)
//            {
//                return NotFound($"GroupProduct with ID {id} not found.");
//            }
//            return Ok(item);
//        }

//        [HttpPost("AddGroupProduct")]
//        public async Task<IActionResult> AddGroupProduct([FromBody] GroupProductsViewModel groupProduct)
//        {
//            var createdItem = await _groupProductsBO.AddGroupProductAsync(groupProduct);
//            if (createdItem == null)
//            {
//                return BadRequest("Error creating group product.");
//            }
//            return CreatedAtAction(nameof(GetGroupProductById), new { id = createdItem.GroupID }, createdItem);
//        }

//        [HttpPut("UpdateGroupProduct/{id}")]
//        public async Task<IActionResult> UpdateGroupProduct(long id, [FromBody] GroupProductsViewModel updatedItem)
//        {
//            var item = await _groupProductsBO.UpdateGroupProductAsync(id, updatedItem);
//            if (item == null)
//            {
//                return NotFound($"GroupProduct with ID {id} not found.");
//            }
//            return Ok(new
//            {
//                message = "GroupProduct Updated Successfully.",
//                data = item
//            });
//        }

//        [HttpDelete("DeleteGroupProduct/{id}")]
//        public async Task<IActionResult> DeleteGroupProduct(long id)
//        {
//            var deleted = await _groupProductsBO.DeleteGroupProductAsync(id);
//            if (!deleted)
//            {
//                return NotFound($"GroupProduct with ID {id} not found.");
//            }
//            return Ok(new
//            {
//                message = "GroupProduct Deleted Successfully.",
//                status = deleted
//            });
//        }
//    }
//}
