using Microsoft.AspNetCore.Mvc;

namespace WebAPIPrectice.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductsController : ControllerBase
{
    [HttpGet]
    public string Get()
    {
        return "Hello World";
    }
}