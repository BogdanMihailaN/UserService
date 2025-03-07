
using AutoMapper;
using Domain.Models;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Repositories.User
{
    public class UserRepository : IUserRepository
    {
        private readonly UserServiceDbContext _context;
        private readonly IMapper _mapper;

        public UserRepository(UserServiceDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<UserModel> GetByIdAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            var userModel = _mapper.Map<UserModel>(user);
            return userModel;
        }

        public async Task<IEnumerable<UserModel>> GetAllAsync()
        {
            var users = await _context.Users.ToListAsync();
            var userModels = _mapper.Map<List<UserModel>>(users);
            return userModels;
        }

        public async Task AddUserAsync(UserModel user)
        {
            var userEntity = _mapper.Map<Domain.Entities.User>(user);
            await _context.Users.AddAsync(userEntity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateUserAsync(UserModel user)
        {
            var userEntity = _mapper.Map<Domain.Entities.User>(user);
            _context.Users.Update(userEntity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(int id)
        {
            var userModel = await GetByIdAsync(id);
            var user = _mapper.Map<Domain.Entities.User>(userModel);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }
    }
}