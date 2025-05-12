using System.Collections.Generic;
using System.Threading.Tasks;
using tutorial8.Entities;

namespace tutorial8.Services.Abstractions
{
    public interface IOrderService
    {
        Task<List<Order>> GetAllOrdersAsync();
        Task<Order?> GetOrderByIdAsync(int orderId);
        Task AddOrderAsync(Order order);
        Task UpdateOrderAsync(Order order);
        Task DeleteOrderAsync(int orderId);
        Task<bool> IsOrderFulfilledAsync(int orderId);
    }
}