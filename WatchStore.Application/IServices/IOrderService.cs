﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchStore.Infrastructure;
using WatchStore.Domain;

namespace WatchStore.Application.IServices
{
    public interface IOrderService
    {
        Task<Order> GetOrderByIdAsync(int orderId);
        Task<IList<Order>> GetOrdersByCustomerIdAsync(int customerId);
        Task<Order> CreateOrderAsync(Order order);
        Task<Order> UpdateOrderAsync(Order order);
        Task DeleteOrderAsync(int orderId);

    }
}
