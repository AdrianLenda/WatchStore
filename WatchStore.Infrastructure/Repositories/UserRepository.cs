using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WatchStore.Domain;
using WatchStore.Domain.Interfaces;

namespace WatchStore.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<User> _dbSet;


        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = context.Set<User>();
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<User> GetByUsernameAsync(string username)
        {
            return await _dbSet.FirstOrDefaultAsync(u => u.Username == username);
        }

        public async Task<User> AddAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task UpdateAsync(User user)
        {
            _dbSet.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(User user)
        {
            _dbSet.Remove(user);
            await _context.SaveChangesAsync();
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}