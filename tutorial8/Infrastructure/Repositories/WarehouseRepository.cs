using System.Data;
using Microsoft.Data.SqlClient;
using tutorial8.Entities;
using tutorial8.Infrastructure;
using tutorial8.Infrastructure.Repositories.Abstractions;

namespace tutorial8.Infrastructure.Repositories;

public class WarehouseRepository : IWarehouseRepository
{
    private readonly IUnitOfWork _unitOfWork;
    private IWarehouseRepository _warehouseRepositoryImplementation;

    public WarehouseRepository(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Warehouse?> GetByIdAsync(int id)
    {
        var connection = await _unitOfWork.GetConnectionAsync();
        var transaction = _unitOfWork.Transaction;

        const string query = @"
            SELECT Id, WarehouseName, WarehouseAddress 
            FROM Warehouse
            WHERE Id = @Id
        ";

        using var command = new SqlCommand(query, connection, transaction);
        command.Parameters.Add("@Id", SqlDbType.Int).Value = id;

        using var reader = await command.ExecuteReaderAsync();
        if (!await reader.ReadAsync())
            return null;

        return new Warehouse
        {
            Id = reader.GetInt32(reader.GetOrdinal("Id")),
            WarehouseName = reader.GetString(reader.GetOrdinal("WarehouseName")),
            WarehouseAddress = reader.GetString(reader.GetOrdinal("WarehouseAddress"))
        };
    }

    public Task<List<Warehouse>> GetAllAsync(SqlConnection connection, SqlTransaction? transaction)
    {
        return _warehouseRepositoryImplementation.GetAllAsync(connection, transaction);
    }

    public Task<Warehouse?> GetByIdAsync(SqlConnection connection, SqlTransaction? transaction, int id)
    {
        return _warehouseRepositoryImplementation.GetByIdAsync(connection, transaction, id);
    }

    public Task InsertAsync(SqlConnection connection, SqlTransaction? transaction, Warehouse warehouse)
    {
        return _warehouseRepositoryImplementation.InsertAsync(connection, transaction, warehouse);
    }

    public Task UpdateAsync(SqlConnection connection, SqlTransaction? transaction, Warehouse warehouse)
    {
        return _warehouseRepositoryImplementation.UpdateAsync(connection, transaction, warehouse);
    }

    public Task DeleteAsync(SqlConnection connection, SqlTransaction? transaction, int id)
    {
        return _warehouseRepositoryImplementation.DeleteAsync(connection, transaction, id);
    }
}