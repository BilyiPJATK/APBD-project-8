using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using tutorial8.Infrastructure.Repositories;
using tutorial8.Infrastructure.Repositories.Abstractions;

namespace tutorial8.Infrastructure;

public sealed class UnitOfWork : IUnitOfWork
{
    private readonly SqlConnection _connection;

    public UnitOfWork(IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Default");
        _connection = new SqlConnection(connectionString);
        
        Products = new ProductRepository(this);
        Warehouses = new WarehouseRepository(this);
        Orders = new OrderRepository(this);
        ProductWarehouses = new ProductWarehouseRepository(this);
    }

    public SqlTransaction? Transaction { get; private set; }

    public IProductRepository Products { get; }
    public IWarehouseRepository Warehouses { get; }
    public IOrderRepository Orders { get; }
    public IProductWarehouseRepository ProductWarehouses { get; }

    public async Task<SqlConnection> GetConnectionAsync()
    {
        if (_connection.State != ConnectionState.Open)
            await _connection.OpenAsync();

        return _connection;
    }

    public async Task BeginTransactionAsync()
    {
        var con = await GetConnectionAsync();
        Transaction = con.BeginTransaction();
    }

    public async Task CommitTransactionAsync()
    {
        if (Transaction is not null)
            await Transaction.CommitAsync();
    }

    public async Task RollbackTransactionAsync()
    {
        if (Transaction is not null)
            await Transaction.RollbackAsync();
    }

    public Task CommitAsync() => CommitTransactionAsync();
    public Task RollbackAsync() => RollbackTransactionAsync();

    public void Dispose()
    {
        Transaction?.Dispose();
        _connection.Dispose();
    }
}