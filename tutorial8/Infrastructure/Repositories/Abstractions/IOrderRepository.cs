using System.Data;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using tutorial8.Entities;

namespace tutorial8.Infrastructure.Repositories.Abstractions
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetAllOrdersAsync(SqlConnection connection, SqlTransaction? transaction);
        Task<Order?> GetOrderByIdAsync(SqlConnection connection, SqlTransaction? transaction, int orderId);
        Task InsertOrderAsync(SqlConnection connection, SqlTransaction? transaction, Order order);
        Task UpdateOrderAsync(SqlConnection connection, SqlTransaction? transaction, Order order);
        Task DeleteOrderAsync(SqlConnection connection, SqlTransaction? transaction, int orderId);
        Task<bool> IsOrderFulfilledAsync(SqlConnection connection, SqlTransaction? transaction, int orderId);
    }
}