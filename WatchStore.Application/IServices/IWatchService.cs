using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchStore.Infrastructure;
using WatchStore.Domain;
using WatchStore.Application.DTOs;

namespace WatchStore.Application.IServices
{
    public interface IWatchService
    {
        Task<IEnumerable<WatchDto>> GetAllWatchesAsync(string sortBy, string filter);
        Task<WatchDto> GetWatchByIdAsync(int id);
        Task<WatchDto> AddWatchAsync(WatchDto watch);
        Task<WatchDto> UpdateWatchAsync(WatchDto watch);
        Task DeleteWatchAsync(int id);
    }
}
