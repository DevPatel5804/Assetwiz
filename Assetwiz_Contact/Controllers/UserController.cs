using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AssetWiz.ViewModels;
using AssetWiz.BusinessObject;
using AssetWiz.Utilities;

namespace AssetWiz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserBusinessObject _userBusinessObject;

        public UserController(UserBusinessObject userBusinessObject)
        {
            _userBusinessObject = userBusinessObject;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserViewModel>>> GetUsers()
        {
            return await _userBusinessObject.GetUsers();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserViewModel>> GetUserById(long id)
        {
            var user = await _userBusinessObject.GetUserById(id);
            if (user == null) return NotFound();
            return user;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(long id, UserViewModel userViewModel)
        {
            var result = await _userBusinessObject.UpdateUser(id, userViewModel);
            if (!result) return NotFound();
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<UserViewModel>> CreateUser(UserViewModel userViewModel)
        {
            var newUser = await _userBusinessObject.CreateUser(userViewModel);
            return CreatedAtAction(nameof(GetUserById), new { id = newUser.Id }, newUser);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(long id)
        {
            var result = await _userBusinessObject.DeleteUser(id);
            if (!result) return NotFound();
            return NoContent();
        }
    }
}
