namespace tutorial8.Entities;

public class Product : BaseEntity
{
    public string ProductName { get; set; } = string.Empty;
    public string ProductDescription { get; set; } = string.Empty;
    public double ProductPrice { get; set; } = 0;
    public List<Order>? Orders { get; set; }
    public List<ProductWareHouse>? Products { get; set; }


}