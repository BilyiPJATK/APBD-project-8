using System.Data;
using Microsoft.Data.SqlClient;
using tutorial8.Entities;
using tutorial8.Infrastructure;
using tutorial8.Infrastructure.Repositories.Abstractions;
namespace tutorial8.Infrastructure.Repositories;


public class ProductWarehouseRepository : IProductWarehouseRepository
{
    private readonly IUnitOfWork _unitOfWork;
    private IProductWarehouseRepository _productWarehouseRepositoryImplementation;

    public ProductWarehouseRepository(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public Task<List<ProductWarehouse>> GetAllAsync()
    {
        return _productWarehouseRepositoryImplementation.GetAllAsync();
    }

    public Task<ProductWarehouse?> GetByIdAsync(int productWarehouseId)
    {
        return _productWarehouseRepositoryImplementation.GetByIdAsync(productWarehouseId);
    }

    Task IProductWarehouseRepository.InsertAsync(ProductWarehouse productWarehouse)
    {
        return _productWarehouseRepositoryImplementation.InsertAsync(productWarehouse);
    }

    public Task UpdateAsync(ProductWarehouse productWarehouse)
    {
        return _productWarehouseRepositoryImplementation.UpdateAsync(productWarehouse);
    }

    public Task DeleteAsync(int productWarehouseId)
    {
        return _productWarehouseRepositoryImplementation.DeleteAsync(productWarehouseId);
    }

    public async Task<int> InsertAsync(ProductWarehouse productWarehouse)
    {
        var connection = await _unitOfWork.GetConnectionAsync();
        var transaction = _unitOfWork.Transaction;

        const string query = @"
            INSERT INTO Product_Warehouse (IdProduct, IdWarehouse, Quantity)
            VALUES (@ProductId, @WarehouseId, @Quantity)
            SELECT CAST(SCOPE_IDENTITY() as int)
        ";

        using var command = new SqlCommand(query, connection, transaction);
        command.Parameters.Add("@ProductId", SqlDbType.Int).Value = productWarehouse.Product.Id;
        command.Parameters.Add("@WarehouseId", SqlDbType.Int).Value = productWarehouse.Id;
        command.Parameters.Add("@Quantity", SqlDbType.Int).Value = productWarehouse.Amount;

        try
        {
            var result = await command.ExecuteScalarAsync();
            return Convert.ToInt32(result);
        }
        catch (SqlException ex)
        {
            throw new InvalidOperationException("Error while inserting product warehouse data.", ex);
        }
    }

    public async Task<bool> IsOrderAlreadyLinkedAsync(int orderId)
    {
        var connection = await _unitOfWork.GetConnectionAsync();
        var transaction = _unitOfWork.Transaction;

        const string query = @"
            SELECT COUNT(1)
            FROM Product_Warehouse
            WHERE IdOrder = @OrderId
        ";

        using var command = new SqlCommand(query, connection, transaction);
        command.Parameters.Add("@OrderId", SqlDbType.Int).Value = orderId;

        var result = await command.ExecuteScalarAsync();
        return Convert.ToInt32(result) > 0;
    }
}