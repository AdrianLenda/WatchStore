using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using WatchStore.Application.DTOs;
using WatchStore.Application.IServices;
using WatchStore.Infrastructure;
using WatchStore.Domain;

namespace WatchStore.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<User> GetUserByIdAsync(int userId)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            return _mapper.Map<User>(user);
        }

        public async Task<IList<User>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllAsync();
            return _mapper.Map<IList<User>>(users);
        }

        public async Task<User> CreateUserAsync(User user)
        {
            var createdUser = await _userRepository.AddAsync(_mapper.Map<User>(user));
            await _userRepository.SaveChangesAsync();
            return _mapper.Map<User>(createdUser);
        }

        public async Task<User> UpdateUserAsync(User user)
        {
            var updatedUser = _userRepository.Update(_mapper.Map<User>(user));
            await _userRepository.SaveChangesAsync();
            return _mapper.Map<User>(updatedUser);
        }

        public async Task DeleteUserAsync(int userId)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            _userRepository.Delete(user);
            await _userRepository.SaveChangesAsync();
        }
    }
}