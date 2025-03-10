using AutoMapper;
using Domain.Models;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Repositories.UserRole
{
    public class UserRoleRepository : IUserRoleRepository
    {
        private readonly UserServiceDbContext _context;
        private readonly IMapper _mapper;

        public UserRoleRepository(UserServiceDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<RoleModel> GetRoleByIdAsync(int id)
        {
            var role = await _context.Roles.AsNoTracking().FirstOrDefaultAsync(u => u.Id == id);
            var roleModel = _mapper.Map<RoleModel>(role);
            return roleModel;
        }

        public async Task<IEnumerable<RoleModel>> GetAllRolesAsync()
        {
            var roles = await _context.Roles.ToListAsync();
            var roleModels = _mapper.Map<List<RoleModel>>(roles);
            return roleModels;
        }

        public async Task AddRoleAsync(RoleModel role)
        {
            var roleEntity = _mapper.Map<Domain.Entities.Role>(role);
            await _context.Roles.AddAsync(roleEntity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateRoleAsync(RoleModel role)
        {
            var roleEntity = _mapper.Map<Domain.Entities.Role>(role);
            _context.Roles.Update(roleEntity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRoleAsync(int id)
        {
            var roleModel = await GetRoleByIdAsync(id);
            var role = _mapper.Map<Domain.Entities.Role>(roleModel);
            if (role != null)
            {
                _context.Roles.Remove(role);
                await _context.SaveChangesAsync();
            }
        }
    }
}