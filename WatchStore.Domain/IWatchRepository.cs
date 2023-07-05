using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchStore.Domain
{
    public interface IWatchRepository
    {
        // Pobierz wszystkie zegarki
        Task<IEnumerable<Watch>> GetAllAsync();

        // Pobierz zegarek o danym ID
        Task<Watch> GetByIdAsync(int id);

        // Dodaj nowy zegarek
        Task AddAsync(Watch watch);

        // Aktualizuj istniejący zegarek
        Task UpdateAsync(Watch watch);

        // Usuń zegarek
        Task DeleteAsync(Watch watch);
    }
}
