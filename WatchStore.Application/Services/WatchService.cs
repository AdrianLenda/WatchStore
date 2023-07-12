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
    public class WatchService : IWatchService
    {
        private readonly IWatchRepository _watchRepository;
        private readonly IMapper _mapper;

        public WatchService(IWatchRepository watchRepository, IMapper mapper)
        {
            _watchRepository = watchRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<WatchDto>> GetAllWatchesAsync(string sortBy, string filter)
        {
            var watches = await _watchRepository.GetAllAsync(sortBy, filter);
            return _mapper.Map<IEnumerable<WatchDto>>(watches);
        }

        public async Task<WatchDto> GetWatchByIdAsync(int id)
        {
            var watch = await _watchRepository.GetByIdAsync(id);
            return _mapper.Map<WatchDto>(watch);
        }

        public async Task<WatchDto> AddWatchAsync(WatchDto watchDto)
        {
            var watch = _mapper.Map<Watch>(watchDto);
            await _watchRepository.AddAsync(watch);
            return _mapper.Map<WatchDto>(watch);
        }

        public async Task<WatchDto> UpdateWatchAsync(WatchDto watchDto)
        {
            var watch = _mapper.Map<Watch>(watchDto);
            await _watchRepository.UpdateAsync(watch);
            return _mapper.Map<WatchDto>(watch);
        }

        public async Task DeleteWatchAsync(int id)
        {
            await _watchRepository.DeleteAsync(id);
        }
    }
}