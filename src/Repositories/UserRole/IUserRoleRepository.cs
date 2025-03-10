using Domain.Models;

namespace Repositories.UserRole
{
    public interface IUserRoleRepository
    {
        Task<RoleModel> GetRoleByIdAsync(int id);
        Task<IEnumerable<RoleModel>> GetAllRolesAsync();
        Task AddRoleAsync(RoleModel user);
        Task UpdateRoleAsync(RoleModel user);
        Task DeleteRoleAsync(int id);
    }
}