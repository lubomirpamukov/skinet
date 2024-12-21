using System;
using System.Text.Json;
using Core.Entities;

namespace Infrastructure.Data;

public static class DataSeeder
{
    public static async Task SeedDataAsync(StoreContext context)
    {
        if(!context.Products.Any())
        {
            //Read all data from the file
            var productData = await File.ReadAllTextAsync("../Infrastructure/Data/SeedData/products.json");

            //Deserialize to c# objects
            var products = JsonSerializer.Deserialize<List<Product>>(productData);

            //Add products to database
            if (products?.Any() != true) return;

            await context.AddRangeAsync(products);
            await context.SaveChangesAsync();
        }
    }
}
