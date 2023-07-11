using System.Collections.Generic;
using System.Threading.Tasks;
using WatchStore.Application.DTOs;

namespace WatchStore.Application.IServices
{
    public interface IOrderItemService
    {
        Task<IEnumerable<OrderItemDto>> GetOrderItemsAsync();
        Task<OrderItemDto> GetOrderItemByIdAsync(int id);
        Task<OrderItemDto> CreateOrderItemAsync(OrderItemDto orderItemDto);
        Task UpdateOrderItemAsync(OrderItemDto orderItemDto);
        Task DeleteOrderItemAsync(int id);
    }
}