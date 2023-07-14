using static FrontEndApp.Pages.CartPage;
using System.Net.Http.Json;

public class CartService
{
    private readonly HttpClient _httpClient;

    public CartService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<CartItem[]> GetCartItems()
    {
        // Replace with the actual API endpoint
        return await _httpClient.GetFromJsonAsync<CartItem[]>("api/cart");
    }

    public async Task RemoveFromCart(CartItem item)
    {
        // Replace with the actual API endpoint
        await _httpClient.DeleteAsync($"api/cart/{item.Watch.Id}");
    }
}