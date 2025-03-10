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
            var user = await _roleRepository.GetRoleByIdAsync(id);
            return user;
        }

        public async Task<IEnumerable<RoleModel>> GetAllRolesAsync()
        {
            var users = await _roleRepository.GetAllRolesAsync();
            return users;
        }

        public async Task<int> CreateRoleAsync(RoleModel user)
        {
            await _roleRepository.AddRoleAsync(user);
            return user.Id;
        }

        public async Task UpdateRoleAsync(int id, RoleModel userDto)
        {
            var user = await _roleRepository.GetRoleByIdAsync(id);
            if (user != null)
            {
                user = userDto;
                await _roleRepository.UpdateRoleAsync(user);
            }
        }

        public async Task DeleteRoleAsync(int id)
        {
            await _roleRepository.DeleteRoleAsync(id);
        }
    }
}