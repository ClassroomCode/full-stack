using EComm.DataAccess;
using EComm.Models;
using Microsoft.AspNetCore.Mvc;

namespace EComm.Controllers;

[ApiController]
public class ProductController : ControllerBase
{
    [HttpGet("products")]
    public List<Product> GetAllProducts()
    {
        var r = new Repository();
        var products = r.GetAllProducts();
        return products;
    }
}
