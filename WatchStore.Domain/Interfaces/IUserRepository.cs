using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchStore.Domain.Interfaces
{
    public interface IUserRepository
    {
        public interface IUserRepository
        {
            Task<IEnumerable<User>> GetAllAsync();
            Task<User> GetByIdAsync(int id);
            Task<User> GetByUsernameAsync(string username);
            Task AddAsync(User user);
            Task UpdateAsync(User user);
            Task DeleteAsync(User user);
            Task SaveChangesAsync(); 

        }

    }
}
