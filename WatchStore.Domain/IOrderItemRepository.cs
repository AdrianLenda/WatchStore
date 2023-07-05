using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchStore.Domain
{
    public interface IOrderItemRepository
    {
        // Pobierz wszystkie elementy zamówienia
        Task<IEnumerable<OrderItem>> GetAllAsync();

        // Pobierz element zamówienia o danym ID
        Task<OrderItem> GetByIdAsync(int id);

        // Pobierz wszystkie elementy danego zamówienia
        Task<IEnumerable<OrderItem>> GetByOrderIdAsync(int orderId);

        // Dodaj nowy element zamówienia
        Task AddAsync(OrderItem orderItem);

        // Aktualizuj istniejący element zamówienia
        Task UpdateAsync(OrderItem orderItem);

        // Usuń element zamówienia
        Task DeleteAsync(OrderItem orderItem);
    }
}
