using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using WatchStore.Application.DTOs;
using WatchStore.Application.IServices;
using WatchStore.Infrastructure;
using WatchStore.Domain;

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

        public async Task<IEnumerable<WatchDto>> GetAllAsync()
        {
            var watches = await _watchRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<WatchDto>>(watches);
        }

        public async Task<WatchDto> GetByIdAsync(int id)
        {
            var watch = await _watchRepository.GetByIdAsync(id);
            return _mapper.Map<WatchDto>(watch);
        }

        public async Task<WatchDto> CreateAsync(WatchDto watchDto)
        {
            var watch = _mapper.Map<Watch>(watchDto);
            await _watchRepository.CreateAsync(watch);
            return _mapper.Map<WatchDto>(watch);
        }

        public async Task<WatchDto> UpdateAsync(WatchDto watchDto)
        {
            var watch = _mapper.Map<Watch>(watchDto);
            await _watchRepository.UpdateAsync(watch);
            return _mapper.Map<WatchDto>(watch);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var watch = await _watchRepository.GetByIdAsync(id);
            if (watch == null)
            {
                return false;
            }

            await _watchRepository.DeleteAsync(watch);
            return true;
        }
    }
}