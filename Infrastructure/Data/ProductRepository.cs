using System;
using System.Security.Cryptography.X509Certificates;
using Core.Entities;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class ProductRepository(StoreContext context) : IProductRepository
{
    private readonly StoreContext _context = context;
    public  void AddProduct(Product product)
    {
        throw new NotImplementedException();

    }

    public void DeleteProduct(Product product)
    {
        throw new NotImplementedException();
    }

    public void EditProduct(Product product)
    {
        throw new NotImplementedException();
    }

    public Task<Product?> GetProductByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyList<Product>> GetProductsAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<bool> ProductExistAsync(int id)
    {
        return await _context.Products.AnyAsync(p => p.Id == id);
    }

    public Task<bool> SaveChangesAsync()
    {
        throw new NotImplementedException();
    }
}
