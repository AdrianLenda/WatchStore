using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchStore.Domain.Interfaces
{
    public interface IWatchRepository
    {
        Task<IEnumerable<Watch>> GetAllAsync(string sortBy = null, string filter = null);
        Task<Watch> GetByIdAsync(int id);
        Task AddAsync(Watch watch);
        Task UpdateAsync(Watch watch);
        Task DeleteAsync(int id);
    }
}
