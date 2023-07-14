using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using FrontEndApp.Models;

namespace FrontEndApp.Services
{
    public class UserApiService
    {
        private readonly HttpClient _http;

        public UserApiService(HttpClient http)
        {
            _http = http;
        }

        public async Task<UserLoginModel> LoginUser(UserLoginModel user)
        {
            var response = await _http.PostAsJsonAsync("api/users/login", user);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<UserLoginModel>();
        }
    }
}