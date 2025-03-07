using Domain.Entities;
using Domain.Models;

namespace Repositories.User
{
    public interface IUserRepository
    {
        Task<UserModel> GetByIdAsync(int id);
        Task<IEnumerable<UserModel>> GetAllAsync();
        Task AddUserAsync(UserModel user);
        Task UpdateUserAsync(UserModel user);
        Task DeleteUserAsync(int id);
    }
}