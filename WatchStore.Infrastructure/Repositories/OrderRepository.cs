using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WatchStore.Domain;

namespace WatchStore.Infrastructure.Repositories
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
            return await _dbSet.Include(o => o.OrderItems).ThenInclude(oi => oi.Watch).ToListAsync();
        }

        public async Task<Order> GetByIdAsync(int id)
        {
            return await _dbSet.Include(o => o.User).Include(o => o.OrderItems).ThenInclude(oi => oi.Watch).FirstOrDefaultAsync(o => o.Id == id);
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

        public async Task<IEnumerable<Order>> GetByUserIdAsync(int userId)
        {
            return await _dbSet
                .Where(order => order.UserId == userId)
                .ToListAsync();
        }
        public async Task CreateAsync(Order order)
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
        }
    }
}
