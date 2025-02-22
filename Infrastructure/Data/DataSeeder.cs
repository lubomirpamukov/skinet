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

            await context.Products.AddRangeAsync(products);
            await context.SaveChangesAsync();
        }

        if(!context.DeliveryMethods.Any())
        {
            //Read all data from the file
            var devliveryData = await File.ReadAllTextAsync("../Infrastructure/Data/SeedData/delivery.json");

            //Deserialize to c# objects
            var deliveryMethods = JsonSerializer.Deserialize<List<DeliveryMethod>>(devliveryData);

            //Add products to database
            if (deliveryMethods?.Any() != true) return;

            await context.DeliveryMethods.AddRangeAsync(deliveryMethods);
            await context.SaveChangesAsync();
        }
    }
}
