using System.Collections.Generic;
using System.Threading.Tasks;
using tutorial8.Entities;
using tutorial8.Infrastructure.Repositories.Abstractions;

namespace tutorial8.Services.Abstractions
{
    public class ProductWarehouseService : IProductWarehouseService
    {
        private readonly IProductWarehouseRepository _productWarehouseRepository;

        public ProductWarehouseService(IProductWarehouseRepository productWarehouseRepository)
        {
            _productWarehouseRepository = productWarehouseRepository;
        }

        public async Task<List<ProductWarehouse>> GetAllProductWarehousesAsync()
        {
            return await _productWarehouseRepository.GetAllAsync();
        }

        public async Task<ProductWarehouse?> GetProductWarehouseByIdAsync(int productWarehouseId)
        {
            return await _productWarehouseRepository.GetByIdAsync(productWarehouseId);
        }

        public async Task AddProductWarehouseAsync(ProductWarehouse productWarehouse)
        {
            await _productWarehouseRepository.InsertAsync(productWarehouse);
        }

        public async Task UpdateProductWarehouseAsync(ProductWarehouse productWarehouse)
        {
            await _productWarehouseRepository.UpdateAsync(productWarehouse);
        }

        public async Task DeleteProductWarehouseAsync(int productWarehouseId)
        {
            await _productWarehouseRepository.DeleteAsync(productWarehouseId);
        }
    }
}