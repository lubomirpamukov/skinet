using System.ComponentModel.DataAnnotations;

namespace API.DTO;

public class AddressDto
{   
    [Required]
    public  string Line1 { get; set; } = null!;

    public  string? Line2 { get; set; }
    
    [Required]
    public  string City { get; set; } = null!;

    public string? State { get; set; }

    [Required]
    public  string PostalCode { get; set; } = null!;

    [Required]
    public  string Country { get; set; } = null!;
}