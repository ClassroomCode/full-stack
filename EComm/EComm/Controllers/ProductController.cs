using EComm.DataAccess;
using EComm.Models;
using Microsoft.AspNetCore.Mvc;

namespace EComm.Controllers;

[ApiController]
public class ProductController(Repository db) : ControllerBase
{
    [HttpGet("products")]
    public async Task<List<Product>> GetAllProducts()
    {
        var products = await db.GetAllProducts();
        return products;
    }

    [HttpGet("product/{id}")]
    public async Task<IActionResult> GetProduct(int id)
    {
        var product = await db.GetProduct(id);
        if (product is null) return NotFound();
        return Ok(product);
    }

    [HttpPatch("product/{id}")]
    public async Task<IActionResult> UpdateProduct(int id, Product product)
    {
        product.ProductID = id;
        var r = await db.UpdateProduct(product);
        if (!r) return NotFound();
        return NoContent(); 
    }

    [HttpPost("product")]
    public async Task<IActionResult> AddProduct(Product product)
    {
        await db.AddProduct(product);
        return CreatedAtAction("GetProduct", 
            new { id = product.ProductID }, product);
    }
}
