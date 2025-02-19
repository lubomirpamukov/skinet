using API.Middleware;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Writers;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<StoreContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
builder.Services.AddScoped<IProductRepository,ProductRepository>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddCors();
builder.Services.AddSingleton<IConnectionMultiplexer>(config => 
{
    var connectionString = builder.Configuration.GetConnectionString("Redis")
    ?? throw new Exception("Cannot get redis connection string");
    var configuration = ConfigurationOptions.Parse(connectionString, true);
    return ConnectionMultiplexer.Connect(configuration);
});
builder.Services.AddSingleton<ICartService, CartService>();
builder.Services.AddAuthorization();
builder.Services.AddIdentityApiEndpoints<AppUser>()
.AddEntityFrameworkStores<StoreContext>();
 
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseMiddleware<ExceptionMiddleware>();

app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:4200", "https://localhost:4200"));

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapControllers();
app.MapIdentityApi<AppUser>();

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
