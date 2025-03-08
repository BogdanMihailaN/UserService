using Domain.Models;

namespace Repositories.Role
{
    public interface IRoleRepository
    {
        Task<RoleModel> GetRoleByIdAsync(int id);
        Task<IEnumerable<RoleModel>> GetAllRolesAsync();
        Task AddRoleAsync(RoleModel user);
        Task UpdateRoleAsync(RoleModel user);
        Task DeleteRoleAsync(int id);
    }
}