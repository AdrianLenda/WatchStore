using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using WatchStore.Application.DTOs;
using WatchStore.Application.IServices;
using WatchStore.Infrastructure;
using WatchStore.Domain;
using WatchStore.Domain.Interfaces;

namespace WatchStore.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<OrderDto> GetOrderByIdAsync(int orderId)
        {
            var order = await _orderRepository.GetByIdAsync(orderId);
            return _mapper.Map<OrderDto>(order);
        }

        public async Task<IList<OrderDto>> GetOrdersByUserIdAsync(int userId)
        {
            var orders = await _orderRepository.GetByUserIdAsync(userId);
            return _mapper.Map<IList<OrderDto>>(orders);
        }

        public async Task<OrderDto> CreateOrderAsync(OrderDto orderDto)
        {
            var order = _mapper.Map<Order>(orderDto);
            await _orderRepository.CreateAsync(order);
            return _mapper.Map<OrderDto>(order);
        }

        public async Task<OrderDto> UpdateOrderAsync(OrderDto orderDto)
        {
            var order = _mapper.Map<Order>(orderDto);
            await _orderRepository.UpdateAsync(order);
            return _mapper.Map<OrderDto>(order);
        }

        public async Task DeleteOrderAsync(int orderId)
        {
            var order = await _orderRepository.GetByIdAsync(orderId);
            await _orderRepository.DeleteAsync(order);
        }
    }
}
