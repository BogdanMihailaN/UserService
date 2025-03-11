
using Domain.Models;
using Repositories.User;

namespace Services.User
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserModel> GetUserByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            return user;
        }

        public async Task<IEnumerable<UserModel>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllAsync();
            return users;
        }

        public async Task<int> CreateUserAsync(UserModel user)
        {
            await _userRepository.AddUserAsync(user);
            return user.Id;
        }

        public async Task UpdateUserAsync(int id, UserModel userDto)
        {
            var user = await _userRepository.GetByIdAsync(id);
            user.Id = id;
            if (user != null)
            {
                user = userDto;
                await _userRepository.UpdateUserAsync(user);
            }
        }

        public async Task DeleteUserAsync(int id)
        {
            await _userRepository.DeleteUserAsync(id);
        }
    }
}