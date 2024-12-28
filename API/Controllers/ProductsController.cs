using API.RequestHelpers;
using Core.Entities;
using Core.Specification;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController(IGenericRepository<Product> _productRepo) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetProductsAsync([FromQuery]ProductSpecParams productSpec)
    {
        var spec = new ProductSpecification(productSpec);
        var products = await _productRepo.ListWithSpecAsync(spec);
        var count = await _productRepo.CountAsync(spec);

        var pagination = new Pagination<Product>(productSpec.PageIndex, productSpec.PageSize, count, products);
        return Ok(pagination);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult>GetProductByIdAsync(int id)
    {
        var product = await  _productRepo.GetByIdAsync(id);
        if(product == null) return NotFound(id);
        return Ok(product);
    }

    [HttpPost]
    public async Task<IActionResult>CreateProductAsync(Product product)
    {
        _productRepo.Add(product);
        if(await _productRepo.SaveChangesAsync())
        {
            return CreatedAtAction("GetProductByIdsync", new {id = product.Id}, product);
        }

        return BadRequest("Problem creating a product");
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult>UpdateProductAsync(int id, Product product)
    {
        if(product.Id != id || !await ProductExistAsync(id))
            return BadRequest("Can't update this product");
        
        _productRepo.Update(product);

        if(await _productRepo.SaveChangesAsync())
        {
            return NoContent();
        }

        return BadRequest("Could not update product");
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult>DeleteProductAsync(int id)
    {
        var product = await _productRepo.GetByIdAsync(id);
        if(product == null)return NotFound("Product dont exist");
            
        _productRepo.Remove(product);
        if(await _productRepo.SaveChangesAsync())
        {
            return NoContent();
        }

        return BadRequest("Could not update product");
    }

    [HttpGet("brands")]
    public async Task<IActionResult>GetBrandsAsync()
    {
        var spec = new BrandListSpecification();
        return Ok(await _productRepo.ListWithSpecAsync(spec));
    }

    [HttpGet("types")]
    public async Task<IActionResult>GetTypesAsync()
    {
       var spec = new TypeListSpecification();
        return Ok(await _productRepo.ListWithSpecAsync(spec));
    }

    private async Task<bool>ProductExistAsync(int id)
    {
        return await _productRepo.ExistsAsync(id);
    }
}
