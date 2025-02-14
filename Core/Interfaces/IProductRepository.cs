using System;
using Core.Entities;

namespace Infrastructure.Interfaces;

public interface IProductRepository
{
    Task<IReadOnlyList<Product>>GetProductsAsync(string? brand , string? type, string? sort);
    Task<IReadOnlyList<string>>GetBrandsAsync();
    Task<IReadOnlyList<string>>GetTypesAsync();
    Task<Product?>GetProductByIdAsync(int id);
    void AddProduct(Product product);
    void EditProduct(Product product);
    void DeleteProduct(Product product);
    Task<bool>ProductExistAsync(int id);
    Task<bool>SaveChangesAsync();
}
