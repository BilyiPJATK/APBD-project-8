using tutorial8.Entities;
using tutorial8.Infrastructure;
using tutorial8.Services.Abstractions;

namespace tutorial8.Services;

public class WarehouseService : IWarehouseService
{
    private readonly IUnitOfWork _unitOfWork;

    public WarehouseService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<Warehouse>> GetAllWarehousesAsync()
    {
        var conn = await _unitOfWork.GetConnectionAsync();
        return await _unitOfWork.Warehouses.GetAllAsync(conn, _unitOfWork.Transaction);
    }

    public async Task<Warehouse?> GetWarehouseByIdAsync(int id)
    {
        var conn = await _unitOfWork.GetConnectionAsync();
        return await _unitOfWork.Warehouses.GetByIdAsync(conn, _unitOfWork.Transaction, id);
    }

    public async Task AddWarehouseAsync(Warehouse warehouse)
    {
        var conn = await _unitOfWork.GetConnectionAsync();
        await _unitOfWork.BeginTransactionAsync();
        try
        {
            await _unitOfWork.Warehouses.InsertAsync(conn, _unitOfWork.Transaction, warehouse);
            await _unitOfWork.CommitTransactionAsync();
        }
        catch
        {
            await _unitOfWork.RollbackTransactionAsync();
            throw;
        }
    }

    public async Task UpdateWarehouseAsync(Warehouse warehouse)
    {
        var conn = await _unitOfWork.GetConnectionAsync();
        await _unitOfWork.BeginTransactionAsync();
        try
        {
            await _unitOfWork.Warehouses.UpdateAsync(conn, _unitOfWork.Transaction, warehouse);
            await _unitOfWork.CommitTransactionAsync();
        }
        catch
        {
            await _unitOfWork.RollbackTransactionAsync();
            throw;
        }
    }

    public async Task DeleteWarehouseAsync(int id)
    {
        var conn = await _unitOfWork.GetConnectionAsync();
        await _unitOfWork.BeginTransactionAsync();
        try
        {
            await _unitOfWork.Warehouses.DeleteAsync(conn, _unitOfWork.Transaction, id);
            await _unitOfWork.CommitTransactionAsync();
        }
        catch
        {
            await _unitOfWork.RollbackTransactionAsync();
            throw;
        }
    }
}
