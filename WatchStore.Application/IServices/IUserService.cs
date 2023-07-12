using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchStore.Infrastructure;
using WatchStore.Domain;

namespace WatchStore.Application.IServices
{
    public interface IUserService
    {
        Task<User> GetUserByIdAsync(int userId);
        Task<IList<User>> GetAllUsersAsync();
        Task<User> CreateUserAsync(User user);
        Task<User> UpdateUserAsync(User user);
        Task DeleteUserAsync(int userId);
    }
}
