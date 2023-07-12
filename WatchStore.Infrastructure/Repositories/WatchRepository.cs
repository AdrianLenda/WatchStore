using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WatchStore.Domain;
using WatchStore.Domain.Interfaces;

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

        public async Task DeleteAsync(int id)
        {
            var watch = await _context.Watches.FindAsync(id);
            if (watch != null)
            {
                _context.Watches.Remove(watch);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<IEnumerable<Watch>> GetAllAsync(string sortBy, string filter)
        {
            IQueryable<Watch> query = _context.Watches;

            if (!string.IsNullOrEmpty(filter))
            {
                query = query.Where(w => w.Brand.Contains(filter));
            }

            switch (sortBy)
            {
                case "name":
                    query = query.OrderBy(w => w.Brand);
                    break;
                case "price":
                    query = query.OrderBy(w => w.Price);
                    break;
                case "manufacturer":
                    query = query.OrderBy(w => w.Manufacturer);
                    break;
                case "promotionSize":
                    query = query.OrderBy(w => w.Price * (1 - w.DiscountPrice));
                    break; ;
                default:
                    break;
            }

            return await query.ToListAsync();
        }
    }
}
