using Microsoft.AspNetCore.Mvc;

namespace EComm.Controllers;

[ApiController]
public class ProductController : ControllerBase
{
    [HttpGet("test")]
    public string Test()
    {
        return "Hello, World!";
    }
}
