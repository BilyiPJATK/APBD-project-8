namespace tutorial8.Entities;

public class Warehouse : BaseEntity
{
    public string WarehouseName { get; set; } = string.Empty;
    public string WarehouseAddress { get; set; } = string.Empty;
    public List<ProductWarehouse>? Products { get; set; }

}