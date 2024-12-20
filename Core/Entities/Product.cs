using System;
using System.ComponentModel.DataAnnotations;

namespace Core.Entities;

public class Product :BaseEntity
{
    [Required]
    public string Name { get;  set; } = null!;

    [Required]
    public string Description { get; set; } = null!;

    [Required]
    public decimal Price {get; set;}

    [Required]
    [Url]
    public string PictureUrl { get; set; } = null!;

    [Required]
    public string Type {get; set;} = null!;

    [Required]
    public string Brand {get; set;} = null!;

    public int QuantityInStock { get; set; }
}
