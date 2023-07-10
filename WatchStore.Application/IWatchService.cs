using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchStore.Application
{
    public interface IWatchService
    {
        Task<IEnumerable<Watch>> GetAllWatchesAsync(string sortBy, string filter);
        Task<Watch> GetWatchByIdAsync(int id);
        Task<Watch> AddWatchAsync(Watch watch);
        Task<Watch> UpdateWatchAsync(Watch watch);
        Task DeleteWatchAsync(int id);
    }
}
