using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchStore.Infrastructure;
using WatchStore.Domain;
using WatchStore.Application.DTOs;

namespace WatchStore.Application.IServices
{
    public interface IOrderService
    {
        Task<OrderDto> GetOrderByIdAsync(int orderId);
        Task<IList<OrderDto>> GetOrdersByUserIdAsync(int userId);
        Task<OrderDto> CreateOrderAsync(OrderDto order);
        Task<OrderDto> UpdateOrderAsync(OrderDto order);
        Task DeleteOrderAsync(int orderId);
    }
}
