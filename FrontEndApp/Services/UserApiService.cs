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

        public async Task<UserModel> GetUserByIdAsync(int userId)
        {
            return await _http.GetFromJsonAsync<UserModel>($"api/users/{userId}");
        }

        public async Task<IList<UserModel>> GetAllUsersAsync()
        {
            return await _http.GetFromJsonAsync<IList<UserModel>>("api/users");
        }

        public async Task<UserModel> CreateUserAsync(UserModel user)
        {
            var response = await _http.PostAsJsonAsync("api/users", user);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<UserModel>();
        }

        public async Task<UserModel> UpdateUserAsync(UserModel user)
        {
            var response = await _http.PutAsJsonAsync($"api/users/{user.Id}", user);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<UserModel>();
        }

        public async Task DeleteUserAsync(int userId)
        {
            var response = await _http.DeleteAsync($"api/users/{userId}");
            response.EnsureSuccessStatusCode();
        }

    }
}