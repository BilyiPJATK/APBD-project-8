namespace tutorial8.Entities;

public class Order : BaseEntity
{
    public Product Product { get; set; } = null!;
    public int Amount { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? FulfilledAt { get; set; } 
    public List<ProductWarehouse>? Products { get; set; }
}