using System;
using System.Security.Cryptography.X509Certificates;
using Core.Entities;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class ProductRepository(StoreContext _context) : IProductRepository
{
    public  void AddProduct(Product product)
    {
        _context.Products.Add(product);
    }

    public void DeleteProduct(Product product)
    {
        _context.Products.Remove(product);
    }

    public void EditProduct(Product product)
    {
        _context.Products.Entry(product).State = EntityState.Modified;
    }

    public async Task<IReadOnlyList<string>> GetBrandsAsync()
    {
        return await _context.Products
                    .Where(p => p.Brand != null)
                    .Select(p => p.Brand)
                    .Distinct()
                    .ToListAsync();
    }

    public async Task<Product?> GetProductByIdAsync(int id)
    {
        return await _context.Products.FindAsync(id);
    }

    public async Task<IReadOnlyList<Product>> GetProductsAsync(string? brand, string? type, string? sort)
    {
        var products = _context.Products.AsQueryable();

        if(!string.IsNullOrWhiteSpace(brand))
        {
            products = products.Where(p => p.Brand == brand);
        }

        if(!string.IsNullOrWhiteSpace(type))
        {
            products = products.Where(p => p.Type == type);
        }

        products = sort switch
        {
            "priceAsc" => products.OrderBy(p => p.Price),
            "priceDesc" => products.OrderByDescending(p => p.Price),
            _ => products.OrderBy(p => p.Name)
        };

        return await products.ToListAsync();
    }

    public async Task<IReadOnlyList<string>> GetTypesAsync()
    {
        return await _context.Products
                    .Where(p => p.Type != null)
                    .Select(p => p.Type)
                    .Distinct()
                    .ToListAsync();
    }

    public async Task<bool> ProductExistAsync(int id)
    {
        return await _context.Products.AnyAsync(p => p.Id == id);
    }

    public async Task<bool> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }
}
