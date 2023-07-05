using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchStore.Domain
{
    public interface IOrderRepository
    {
        // Pobierz wszystkie zamówienia
        Task<IEnumerable<Order>> GetAllAsync();

        // Pobierz zamówienie o danym ID
        Task<Order> GetByIdAsync(int id);

        // Pobierz wszystkie zamówienia danego użytkownika
        Task<IEnumerable<Order>> GetByUserIdAsync(int userId);

        // Dodaj nowe zamówienie
        Task AddAsync(Order order);

        // Aktualizuj istniejące zamówienie
        Task UpdateAsync(Order order);

        // Usuń zamówienie
        Task DeleteAsync(Order order);
    }
}
