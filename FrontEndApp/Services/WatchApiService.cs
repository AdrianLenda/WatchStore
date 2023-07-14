using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using FrontEndApp.Models;

namespace FrontEndApp.Services
{
    public class WatchApiService
    {
        private readonly HttpClient _httpClient;

        public WatchApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<ProductModel>> GetWatchesAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<ProductModel>>("api/watches");
        }

        public async Task<ProductModel> GetWatchByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<ProductModel>($"api/watches/{id}");
        }
    }
}