using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using WatchStore.Application.DTOs;
using WatchStore.Application.IServices;
using WatchStore.Infrastructure;
using WatchStore.Domain;

namespace WatchStore.Application.Services
{
    public class OrderItemService : IOrderItemService
    {
        private readonly IOrderItemRepository _orderItemRepository;
        private readonly IMapper _mapper;

        public OrderItemService(IOrderItemRepository orderItemRepository, IMapper mapper)
        {
            _orderItemRepository = orderItemRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OrderItemDto>> GetOrderItemsAsync()
        {
            var orderItems = await _orderItemRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<OrderItemDto>>(orderItems);
        }

        public async Task<OrderItemDto> GetOrderItemByIdAsync(int id)
        {
            var orderItem = await _orderItemRepository.GetByIdAsync(id);
            return _mapper.Map<OrderItemDto>(orderItem);
        }

        public async Task<OrderItemDto> CreateOrderItemAsync(OrderItemDto orderItemDto)
        {
            var orderItem = _mapper.Map<OrderItem>(orderItemDto);
            await _orderItemRepository.AddAsync(orderItem);
            return _mapper.Map<OrderItemDto>(orderItem);
        }

        public async Task UpdateOrderItemAsync(OrderItemDto orderItemDto)
        {
            var orderItem = _mapper.Map<OrderItem>(orderItemDto);
            await _orderItemRepository.UpdateAsync(orderItem);
        }

        public async Task DeleteOrderItemAsync(int id)
        {
            await _orderItemRepository.DeleteAsync(id);
        }
    }
}