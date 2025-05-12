using System;
using System.Collections.Generic;
using System.Linq;
using tutorial8.Contracts.Requests;
using tutorial8.Contracts.Responses;
using tutorial8.Entities;

namespace tutorial8.Mappers
{
    public static class ProductWarehouseMapper
    {
        public static AddProductToWarehouseResponse MapToAddProductToWarehouseResponse(this ProductWarehouse productWarehouse)
        {
            if (productWarehouse == null)
                throw new ArgumentNullException(nameof(productWarehouse));

            return new AddProductToWarehouseResponse(productWarehouse.Product.Id);
        }

        public static GetProductWarehouseResponse? MapToGetProductWarehouseResponse(this ProductWarehouse productWarehouse)
        {
            if (productWarehouse == null || productWarehouse.Product == null || productWarehouse.Product.ProductName == null)
                return null;

            return new GetProductWarehouseResponse(
                productWarehouse.Product.Id,
                productWarehouse.Product.ProductName, 
                productWarehouse.Product.ProductName, 
                productWarehouse.Amount,
                productWarehouse.Price,
                productWarehouse.CreatedAt
            );
        }

        public static List<GetProductWarehouseResponse?> MapToGetProductWarehouseResponses(this ICollection<ProductWarehouse> productWarehouses)
        {
            return productWarehouses.Select(x => x.MapToGetProductWarehouseResponse()).ToList();
        }

        public static ProductWarehouse MapRequestToEntity(this AddProductToWarehouseRequest request, Product product)
        {
            if (request.Amount <= 0)
                throw new ArgumentException("Amount must be greater than 0.", nameof(request.Amount));

            var productWarehouse = new ProductWarehouse
            {
                Product = product, 
                Amount = request.Amount,
                Price = (int)product.ProductPrice,
                CreatedAt = request.CreatedAt
            };

            return productWarehouse;
        }
    }
}
