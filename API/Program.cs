using Infrastructure.Data;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Writers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<StoreContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();

builder.Services.AddScoped<IProductRepository,ProductRepository>();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline. test test test 
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapControllers();

try
{
    using var scope = app.Services.CreateScope(); //creating a scope
    var services = scope.ServiceProvider; // getting service provider
    var context = services.GetRequiredService<StoreContext>(); //initializing database context
    await context.Database.MigrateAsync(); // auto migrating changes to the database
    await DataSeeder.SeedDataAsync(context); // seeding data to the database
}
catch (System.Exception ex)
{
    
    Console.WriteLine(ex);
}

app.Run();
