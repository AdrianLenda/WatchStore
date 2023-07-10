using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchStore.Domain;

namespace WatchStore.Infrastructure
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<Order> _dbSet;

        public OrderRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = context.Set<Order>();
        }

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            return await _dbSet.Include(o => o.User).Include(o => o.Watch).ToListAsync();
        }

        public async Task<Order> GetByIdAsync(int id)
        {
            return await _dbSet.Include(o => o.User).Include(o => o.Watch).FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task AddAsync(Order order)
        {
            await _dbSet.AddAsync(order);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Order order)
        {
            _dbSet.Update(order);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Order order)
        {
            _dbSet.Remove(order);
            await _context.SaveChangesAsync();
        }
    }
}
