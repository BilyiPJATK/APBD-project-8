namespace tutorial8.Contracts.Responses;

public record struct GetProductWarehouseResponse(
    int Id,
    string ProductName,
    string WarehouseName,
    int Amount,
    double Price,
    DateTime CreatedAt
);