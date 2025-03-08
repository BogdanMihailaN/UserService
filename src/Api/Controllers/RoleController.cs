using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Role;

namespace UserService.Api
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoleAsync(int id)
        {
            var user = await _roleService.GetRoleByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRolesAsync()
        {
            var users = await _roleService.GetAllRolesAsync();
            return Ok(users);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRoleAsync([FromBody] RoleModel roleDto)
        {
            var userId = await _roleService.CreateRoleAsync(roleDto);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRoleAsync(int id, [FromBody] RoleModel roleDto)
        {
            await _roleService.UpdateRoleAsync(id, roleDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoleAsync(int id)
        {
            await _roleService.DeleteRoleAsync(id);
            return NoContent();
        }
    }
}