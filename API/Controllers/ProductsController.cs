using System;
using Core.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController(StoreContext context) : ControllerBase
{
    private readonly StoreContext _context = context;

    [HttpGet]
    public async Task<IActionResult> GetProductsAsync()
    {
        var products = await _context.Products.ToArrayAsync();
        return Ok(products);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult>GetProductByIdsync(int id)
    {
        var product = await  _context.Products.FirstOrDefaultAsync(x => x.Id == id);
        if(product == null) return NotFound(id);
        return Ok(product);
    }

    [HttpPost]
    public async Task<IActionResult>CreateProductAsync(Product product)
    {
        await _context.Products.AddAsync(product);
        await _context.SaveChangesAsync();
        return Ok();
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult>UpdateProductAsync(int id, Product product)
    {
        if(product.Id != id || !await ProductExistAsync(id))
            return BadRequest("Can't update this product");
        
        _context.Products.Entry(product).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult>DeleteProductAsync(int id)
    {
        var productTodelete = await _context.Products.FindAsync(id);
        if(productTodelete == null) return NotFound();
        _context.Products.Remove(productTodelete);
        await _context.SaveChangesAsync();
        return NoContent();
    }

    private async Task<bool>ProductExistAsync(int id)
    {
        return await _context.Products.AnyAsync(p => p.Id == id);
    }
}
