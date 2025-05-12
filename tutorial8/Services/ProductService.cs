using tutorial8.Entities;
using tutorial8.Infrastructure;
using tutorial8.Infrastructure.Repositories.Abstractions;
using tutorial8.Services.Abstractions;

namespace tutorial8.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ProductService(IProductRepository productRepository, IUnitOfWork unitOfWork)
    {
        _productRepository = productRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<List<Product>> GetAllProductsAsync()
    {
        return await _productRepository.GetAllAsync();
    }

    public async Task<Product> GetProductByIdAsync(int id)
    {
        var product = await _productRepository.GetByIdAsync(id);
        if (product == null)
            throw new KeyNotFoundException($"Product with ID {id} not found.");

        return product;
    }

    public async Task AddProductAsync(Product product)
    {
        await _productRepository.AddAsync(product);
    }

    public async Task UpdateProductAsync(Product product)
    {
        await _productRepository.UpdateAsync(product);
    }

    public async Task DeleteProductAsync(int id)
    {
        await _productRepository.DeleteAsync(id);
    }
}