using System.Collections.Generic;
using System.Threading.Tasks;
using tutorial8.Entities;

namespace tutorial8.Services.Abstractions
{
    public interface IProductWarehouseService
    {
        Task<List<ProductWarehouse>> GetAllProductWarehousesAsync();
        Task<ProductWarehouse?> GetProductWarehouseByIdAsync(int productWarehouseId);
        Task AddProductWarehouseAsync(ProductWarehouse productWarehouse);
        Task UpdateProductWarehouseAsync(ProductWarehouse productWarehouse);
        Task DeleteProductWarehouseAsync(int productWarehouseId);
    }
}