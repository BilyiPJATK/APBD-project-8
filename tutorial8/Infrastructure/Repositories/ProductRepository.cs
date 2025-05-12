using Microsoft.Data.SqlClient;
using tutorial8.Entities;
using tutorial8.Infrastructure;
using System.Data;
using tutorial8.Infrastructure.Repositories.Abstractions;

namespace tutorial8.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        private IProductRepository _productRepositoryImplementation;

        public ProductRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<List<Product>> GetAllAsync()
        {
            return _productRepositoryImplementation.GetAllAsync();
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            var connection = await _unitOfWork.GetConnectionAsync();
            var transaction = _unitOfWork.Transaction;

            var query = "SELECT IdProduct, Name, Description, Price FROM Product WHERE IdProduct = @Id";

            using var command = new SqlCommand(query, connection, transaction);
            command.Parameters.Add("@Id", SqlDbType.Int).Value = id; 

            try
            {
                using var reader = await command.ExecuteReaderAsync();
                if (!await reader.ReadAsync())
                    return null;

                return new Product
                {
                    Id = reader.GetInt32(reader.GetOrdinal("IdProduct")),
                    ProductName = reader.GetString(reader.GetOrdinal("Name")),
                    ProductDescription = reader.GetString(reader.GetOrdinal("Description")),
                    ProductPrice = reader.GetDouble(reader.GetOrdinal("Price"))
                };
            }
            catch (SqlException ex)
            {
                throw new InvalidOperationException("An error occurred while retrieving the product.", ex);
            }
        }

        public Task AddAsync(Product product)
        {
            return _productRepositoryImplementation.AddAsync(product);
        }

        public Task UpdateAsync(Product product)
        {
            return _productRepositoryImplementation.UpdateAsync(product);
        }

        public Task DeleteAsync(int id)
        {
            return _productRepositoryImplementation.DeleteAsync(id);
        }

        public async Task<decimal> GetPriceByIdAsync(int id)
        {
            var connection = await _unitOfWork.GetConnectionAsync();
            var transaction = _unitOfWork.Transaction;

            var query = "SELECT Price FROM Product WHERE IdProduct = @Id";

            using var command = new SqlCommand(query, connection, transaction);
            command.Parameters.Add("@Id", SqlDbType.Int).Value = id; 

            try
            {
                var result = await command.ExecuteScalarAsync();
                if (result == null)
                    throw new InvalidOperationException("Product not found.");
                
                return Convert.ToDecimal(result);
            }
            catch (SqlException ex)
            {
                throw new InvalidOperationException("An error occurred while retrieving the product price.", ex);
            }
        }
    }
}
