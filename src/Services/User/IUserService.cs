using Domain.Models;

namespace Services.User
{
    public interface IUserService
    {
        Task<UserModel> GetUserByIdAsync(int id);
        Task<IEnumerable<UserModel>> GetAllUsersAsync();
        Task<int> CreateUserAsync(UserModel user);
        Task UpdateUserAsync(int id, UserModel userDto);
        Task DeleteUserAsync(int id);
    }
}