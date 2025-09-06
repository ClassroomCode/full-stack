using EComm.DataAccess;
using EComm.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EComm.Controllers;

[ApiController]
public class ProductController(EFRepository db) : ControllerBase
{
    [HttpGet("products")]
    public async Task<List<Product>> GetAllProducts()
    {
        //return await db.Products
        //    .FromSql($"SELECT * FROM Products")
        //    .ToListAsync();

        return await db.Products.AsNoTracking().ToListAsync();
        
        //var products = await db.GetAllProducts();
        //return products;
    }

    [HttpGet("product/{id}")]
    public async Task<IActionResult> GetProduct(int id)
    {
        var product = await db.Products.FindAsync(id);
        if (product is null) return NotFound();
        return Ok(product);

        //var product = await db.GetProduct(id);
        //if (product is null) return NotFound();
        //return Ok(product);
    }

    [HttpPatch("product/{id}")]
    public async Task<IActionResult> UpdateProduct(int id, Product product)
    {
        var existingProduct = await db.Products.FindAsync(id);
        if (existingProduct is null) return NotFound();

        existingProduct.ProductName = product.ProductName;
        await db.SaveChangesAsync();
        return NoContent();

        //product.ProductID = id;
        //var r = await db.UpdateProduct(product);
        //if (!r) return NotFound();
        //return NoContent(); 
    }

    [HttpPost("product")]
    public async Task<IActionResult> AddProduct(Product product)
    {
        db.Products.Add(product);
        await db.SaveChangesAsync();
        return CreatedAtAction("GetProduct",
            new { id = product.ProductID }, product);

        //await db.AddProduct(product);
        //return CreatedAtAction("GetProduct", 
        //    new { id = product.ProductID }, product);
    }
}
