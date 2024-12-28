namespace Core.Specification;

public class ProductSpecParams
{
    private List<string> _brands = [];
    public List<string> Brands
    {
        get => _brands; // Nike,Addidas
        set
        {
            _brands = value.SelectMany(x => x.Split(',', StringSplitOptions.RemoveEmptyEntries)).ToList();
        }
    }
    
    private List<string> _types = [];
    public List<string> Types // boards , gloves etc
    {
        get => _types;
        set
        {
            _types = value.SelectMany(x => x.Split(',', StringSplitOptions.RemoveEmptyEntries)).ToList();
        }
    }

    public string? Sort { get; set; }
    
}
