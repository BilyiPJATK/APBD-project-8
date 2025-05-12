using Microsoft.Data.SqlClient;
using tutorial8.Infrastructure.Repositories.Abstractions;

namespace tutorial8.Infrastructure;

public interface IUnitOfWork : IDisposable
{
    IProductRepository Products { get; }
    IWarehouseRepository Warehouses { get; }
    IOrderRepository Orders { get; }
    IProductWarehouseRepository ProductWarehouses { get; }

    Task BeginTransactionAsync();
    Task CommitAsync();
    Task<SqlConnection> GetConnectionAsync();
    SqlTransaction? Transaction { get; }
    Task CommitTransactionAsync();
    Task RollbackTransactionAsync();
    Task RollbackAsync();
}
