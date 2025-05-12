using System.Data;
using Microsoft.Data.SqlClient;
using tutorial8.Entities;
using tutorial8.Infrastructure;
using tutorial8.Infrastructure.Repositories.Abstractions;

public class OrderRepository : IOrderRepository
{
    private readonly IUnitOfWork _unitOfWork;

    public OrderRepository(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Order?> GetMatchingOrderAsync(int productId, int amount, DateTime beforeCreatedAt)
    {
        var connection = await _unitOfWork.GetConnectionAsync();
        var transaction = _unitOfWork.Transaction;

        const string query = @"
            SELECT TOP 1 Id, IdProduct, Amount, CreatedAt, FulfilledAt
            FROM [Order]
            WHERE IdProduct = @ProductId AND Amount = @Amount AND CreatedAt < @BeforeCreatedAt
        ";

        using var command = new SqlCommand(query, connection, transaction);
        command.Parameters.Add("@ProductId", SqlDbType.Int).Value = productId;
        command.Parameters.Add("@Amount", SqlDbType.Int).Value = amount;
        command.Parameters.Add("@BeforeCreatedAt", SqlDbType.DateTime).Value = beforeCreatedAt;

        using var reader = await command.ExecuteReaderAsync();
        if (!await reader.ReadAsync())
            return null;

        return new Order
        {
            Id = reader.GetInt32(reader.GetOrdinal("Id")),
            Amount = reader.GetInt32(reader.GetOrdinal("Amount")),
            CreatedAt = reader.GetDateTime(reader.GetOrdinal("CreatedAt")),
            FulfilledAt = reader.IsDBNull(reader.GetOrdinal("FulfilledAt"))
                         ? (DateTime?)null
                         : reader.GetDateTime(reader.GetOrdinal("FulfilledAt")),
            Product = new Product
            {
                Id = reader.GetInt32(reader.GetOrdinal("IdProduct"))
            }
        };
    }

    public async Task<bool> IsOrderFulfilledAsync(int orderId)
    {
        var connection = await _unitOfWork.GetConnectionAsync();
        var transaction = _unitOfWork.Transaction;

        const string query = @"
            SELECT COUNT(1)
            FROM Product_Warehouse
            WHERE IdOrder = @OrderId
        ";

        using var command = new SqlCommand(query, connection, transaction);
        command.Parameters.Add("@OrderId", SqlDbType.Int).Value = orderId;

        var result = await command.ExecuteScalarAsync();
        return Convert.ToInt32(result) > 0;
    }

    public async Task UpdateFulfilledAtAsync(int orderId, DateTime fulfilledAt)
    {
        var connection = await _unitOfWork.GetConnectionAsync();
        var transaction = _unitOfWork.Transaction;

        const string query = @"
            UPDATE [Order]
            SET FulfilledAt = @FulfilledAt
            WHERE Id = @OrderId
        ";

        using var command = new SqlCommand(query, connection, transaction);
        command.Parameters.Add("@FulfilledAt", SqlDbType.DateTime).Value = fulfilledAt;
        command.Parameters.Add("@OrderId", SqlDbType.Int).Value = orderId;

        await command.ExecuteNonQueryAsync();
    }

    public Task<List<Order>> GetAllOrdersAsync(SqlConnection connection, SqlTransaction? transaction)
    {
        throw new NotImplementedException();
    }

    public Task<Order?> GetOrderByIdAsync(SqlConnection connection, SqlTransaction? transaction, int orderId)
    {
        throw new NotImplementedException();
    }

    public Task InsertOrderAsync(SqlConnection connection, SqlTransaction? transaction, Order order)
    {
        throw new NotImplementedException();
    }

    public Task UpdateOrderAsync(SqlConnection connection, SqlTransaction? transaction, Order order)
    {
        throw new NotImplementedException();
    }

    public Task DeleteOrderAsync(SqlConnection connection, SqlTransaction? transaction, int orderId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> IsOrderFulfilledAsync(SqlConnection connection, SqlTransaction? transaction, int orderId)
    {
        throw new NotImplementedException();
    }
}
