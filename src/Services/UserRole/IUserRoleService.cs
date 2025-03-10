using Domain.Models;

namespace Services.UserRole;

public interface IUserRoleService
{
    Task<RoleModel> GetRoleByIdAsync(int id);
    Task<IEnumerable<RoleModel>> GetAllRolesAsync();
    Task<int> CreateRoleAsync(RoleModel user);
    Task UpdateRoleAsync(int id, RoleModel userDto);
    Task DeleteRoleAsync(int id);
}