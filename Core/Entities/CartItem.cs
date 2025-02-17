using System.ComponentModel.DataAnnotations;

namespace Core.Entities;

public class CartItem
{
    public int ProductId { get; set; }

    public required  string ProductName { get; set; } = null!;

    public decimal Price { get; set; }
    public int Quantity { get; set; }

    public required string PictureUrl { get; set; } = null!;

    public required string Brand { get; set; } = null!;

    public required string Type { get; set; } = null!;
}