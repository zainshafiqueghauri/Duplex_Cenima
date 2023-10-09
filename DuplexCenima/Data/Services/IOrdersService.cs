using DuplexCenima.Models;

namespace DuplexCenima.Data.Services
{
    public interface IOrdersService
    {
        Task StoreOrderAsync(List<ShoppingCartitem> items, string userId, string userEmailAddress);
        Task<List<Order>> GetOrdersByUserIdAsync(string userId);
    }
}
