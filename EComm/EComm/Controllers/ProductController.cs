using EComm.DataAccess;
using EComm.Models;
using Microsoft.AspNetCore.Mvc;

namespace EComm.Controllers;

[ApiController]
public class ProductController(Repository db) : ControllerBase
{
    [HttpGet("products")]
    public List<Product> GetAllProducts()
    {
        var products = db.GetAllProducts();
        return products;
    }

    [HttpGet("product/{id}")]
    public Product GetProduct(int id)
    {
        var product = db.GetProduct(id);
        return product;
    }
}
