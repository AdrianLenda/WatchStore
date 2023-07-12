using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WatchStore.Domain;

namespace WatchStore.Infrastructure.Repositories
{
    public class WatchRepository : IWatchRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<Watch> _dbSet;

        public WatchRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = context.Set<Watch>();
        }

        public async Task<IEnumerable<Watch>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<Watch> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task AddAsync(Watch watch)
        {
            await _dbSet.AddAsync(watch);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Watch watch)
        {
            _dbSet.Update(watch);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Watch watch)
        {
            _dbSet.Remove(watch);
            await _context.SaveChangesAsync();
        }
    }
}
