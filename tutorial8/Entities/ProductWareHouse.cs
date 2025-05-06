namespace tutorial8.Entities;

public class ProductWareHouse : BaseEntity
{
    public Product Product { get; set; } = null!;
    public Order Order { get; set; } = null!;
    public int Amount { get; set; }
    public int Price { get; set; }
    public DateTime CreatedAt { get; set; }
}