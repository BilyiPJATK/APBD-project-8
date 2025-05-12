using System.Collections.Generic;
using System.Threading.Tasks;
using tutorial8.Entities;

namespace tutorial8.Infrastructure.Repositories.Abstractions
{
    public interface IProductWarehouseRepository
    {
        Task<List<ProductWarehouse>> GetAllAsync();
        Task<ProductWarehouse?> GetByIdAsync(int productWarehouseId);
        Task InsertAsync(ProductWarehouse productWarehouse);
        Task UpdateAsync(ProductWarehouse productWarehouse);
        Task DeleteAsync(int productWarehouseId);
    }
}