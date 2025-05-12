using System.ComponentModel.DataAnnotations;

namespace tutorial8.Contracts.Requests;

public class AddProductToWarehouseRequest
{
    [Required]
    public int ProductId { get; set; }

    [Required]
    public int WarehouseId { get; set; }

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Amount must be greater than 0")]
    public int Amount { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; }
}