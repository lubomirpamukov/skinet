using System.ComponentModel.DataAnnotations;

namespace API.DTO;

public class CreateProductDto
{
    [Required]
    public string Name { get;  set; } = null!;

    [Required]
    public string Description { get; set; } = null!;

    [Range(0.1, double.MaxValue, ErrorMessage = "price must be positive number" )]
    public decimal Price {get; set;}

    [Required]
    [Url]
    public string PictureUrl { get; set; } = null!;

    [Required]
    public string Type {get; set;} = null!;

    [Required]
    public string Brand {get; set;} = null!;

    [Range(1, int.MaxValue, ErrorMessage = "Quantity must be positive number")]
    public int QuantityInStock { get; set; }
}
