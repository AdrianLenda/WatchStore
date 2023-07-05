using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchStore.Domain
{
    public class OrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IWatchRepository _watchRepository;
        private readonly IUserRepository _userRepository;

        public OrderService(IOrderRepository orderRepository, IWatchRepository watchRepository, IUserRepository userRepository)
        {
            _orderRepository = orderRepository;
            _watchRepository = watchRepository;
            _userRepository = userRepository;
        }

        public async Task<Order> CreateOrderAsync(int userId, int watchId, int quantity)
        {
            // Pobierz użytkownika i zegarek z bazy danych
            var user = await _userRepository.GetByIdAsync(userId);
            var watch = await _watchRepository.GetByIdAsync(watchId);

            // Stwórz nowe zamówienie
            var order = new Order
            {
                User = user,
                OrderDate = DateTime.Now,
                Status = "Pending"
            };

            // Dodaj element zamówienia do zamówienia
            var orderItem = new OrderItem
            {
                Watch = watch,
                Quantity = quantity,
                UnitPrice = watch.Price
            };
            order.OrderItems.Add(orderItem);

            // Zapisz zamówienie w bazie danych
            await _orderRepository.AddAsync(order);

            return order;
        }
        public async Task<Order> CancelOrderAsync(int orderId)
        {
            // Pobierz zamówienie z bazy danych
            var order = await _orderRepository.GetByIdAsync(orderId);

            // Sprawdź, czy zamówienie istnieje
            if (order == null)
            {
                throw new Exception($"Order with id {orderId} does not exist.");
            }

            // Sprawdź, czy zamówienie można anulować
            if (order.Status != "Pending")
            {
                throw new Exception($"Order with id {orderId} cannot be cancelled because it is in {order.Status} status.");
            }

            // Anuluj zamówienie
            order.Status = "Cancelled";

            // Zaktualizuj zamówienie w bazie danych
            await _orderRepository.UpdateAsync(order);

            return order;
        }
    }
}
