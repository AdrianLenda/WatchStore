using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WatchStore.Domain;
using WatchStore.Domain.Interfaces;

namespace WatchStore.Infrastructure.Repositories
{
    public class OrderItemRepository : IOrderItemRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<OrderItem> _dbSet;

        public OrderItemRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = context.Set<OrderItem>();
        }

        public async Task<IEnumerable<OrderItem>> GetAllAsync()
        {
            return await _dbSet.Include(oi => oi.Order).Include(oi => oi.Watch).ToListAsync();
        }

        public async Task<OrderItem> GetByIdAsync(int id)
        {
            return await _dbSet.Include(oi => oi.Order).Include(oi => oi.Watch).FirstOrDefaultAsync(oi => oi.Id == id);
        }

        public async Task AddAsync(OrderItem orderItem)
        {
            await _dbSet.AddAsync(orderItem);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(OrderItem orderItem)
        {
            _dbSet.Update(orderItem);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(OrderItem orderItem)
        {
            _dbSet.Remove(orderItem);
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<OrderItem>> GetByOrderIdAsync(int orderId)
        {
            return await _dbSet
                .Where(orderItem => orderItem.OrderId == orderId)
                .ToListAsync();
        }

    }
}
