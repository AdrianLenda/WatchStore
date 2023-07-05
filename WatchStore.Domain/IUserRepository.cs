using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchStore.Domain
{
    public interface IUserRepository
    {
        // Pobierz wszystkich użytkowników
        Task<IEnumerable<User>> GetAllAsync();

        // Pobierz użytkownika o danym ID
        Task<User> GetByIdAsync(int id);

        // Pobierz użytkownika o danej nazwie użytkownika
        Task<User> GetByUsernameAsync(string username);

        // Dodaj nowego użytkownika
        Task AddAsync(User user);

        // Aktualizuj istniejącego użytkownika
        Task UpdateAsync(User user);

        // Usuń użytkownika
        Task DeleteAsync(User user);
    }
}
