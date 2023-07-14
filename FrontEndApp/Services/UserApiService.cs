using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using FrontEndApp.Models;
using System.Collections.Generic;

namespace FrontEndApp.Services
{
    public class UserApiService
    {
        private readonly HttpClient _http;

        public UserApiService(HttpClient http)
        {
            _http = http;
        }

        public async Task<UserLoginModel> GetUserByIdAsync(int userId)
        {
            return await _http.GetFromJsonAsync<UserLoginModel>($"api/users/{userId}");
        }

        public async Task<IList<UserLoginModel>> GetAllUsersAsync()
        {
            return await _http.GetFromJsonAsync<IList<UserLoginModel>>("api/users");
        }

        public async Task<UserLoginModel> CreateUserAsync(UserLoginModel user)
        {
            var response = await _http.PostAsJsonAsync("api/users", user);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<UserLoginModel>();
        }

        public async Task<UserLoginModel> UpdateUserAsync(UserLoginModel user)
        {
            var response = await _http.PutAsJsonAsync($"api/users/{user.Id}", user);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<UserLoginModel>();
        }

        public async Task DeleteUserAsync(int userId)
        {
            var response = await _http.DeleteAsync($"api/users/{userId}");
            response.EnsureSuccessStatusCode();
        }
        public async Task<UserLoginModel> LoginUser(UserLoginModel user)
        {
            var response = await _http.PostAsJsonAsync("api/users/login", user);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<UserLoginModel>();
        }

    }
}