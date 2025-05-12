using System.Data;
using Microsoft.Data.SqlClient;
using tutorial8.Entities;

namespace tutorial8.Infrastructure.Repositories.Abstractions;

public interface IWarehouseRepository
{
    Task<List<Warehouse>> GetAllAsync(SqlConnection connection, SqlTransaction? transaction);
    Task<Warehouse?> GetByIdAsync(SqlConnection connection, SqlTransaction? transaction, int id);
    Task InsertAsync(SqlConnection connection, SqlTransaction? transaction, Warehouse warehouse);
    Task UpdateAsync(SqlConnection connection, SqlTransaction? transaction, Warehouse warehouse);
    Task DeleteAsync(SqlConnection connection, SqlTransaction? transaction, int id);
}