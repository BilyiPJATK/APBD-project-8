namespace tutorial8.Entities;

public class WareHouse : BaseEntity
{
    public string WareHouseName { get; set; } = string.Empty;
    public string WareHouseAddress { get; set; } = string.Empty;
    public List<ProductWareHouse>? Products { get; set; }

}