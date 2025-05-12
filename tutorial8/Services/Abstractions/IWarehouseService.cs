using tutorial8.Entities;

namespace tutorial8.Services.Abstractions;
public interface IWarehouseService
{
    Task<List<Warehouse>> GetAllWarehousesAsync();
    Task<Warehouse?> GetWarehouseByIdAsync(int id);
    Task AddWarehouseAsync(Warehouse warehouse);
    Task UpdateWarehouseAsync(Warehouse warehouse);
    Task DeleteWarehouseAsync(int id);
}