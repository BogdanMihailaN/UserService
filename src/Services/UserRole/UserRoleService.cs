using Domain.Models;
using Repositories.UserRole;

namespace Services.UserRole
{
    public class RoleService : IUserRoleService
    {
        private readonly IUserRoleRepository _roleRepository;

        public RoleService(IUserRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<RoleModel> GetRoleByIdAsync(int id)
        {
            var userRole = await _roleRepository.GetRoleByIdAsync(id);
            return userRole;
        }

        public async Task<IEnumerable<RoleModel>> GetAllRolesAsync()
        {
            var userRoles = await _roleRepository.GetAllRolesAsync();
            return userRoles;
        }

        public async Task<int> CreateRoleAsync(RoleModel user)
        {
            await _roleRepository.AddRoleAsync(user);
            return user.Id;
        }

        public async Task UpdateRoleAsync(int id, RoleModel userDto)
        {
            var userRole = await _roleRepository.GetRoleByIdAsync(id);
            if (userRole != null)
            {
                userRole = userDto;
                userRole.Id = id;
                await _roleRepository.UpdateRoleAsync(userRole);
            }
        }

        public async Task DeleteRoleAsync(int id)
        {
            await _roleRepository.DeleteRoleAsync(id);
        }
    }
}