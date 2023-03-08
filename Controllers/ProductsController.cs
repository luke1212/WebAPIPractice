using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPIPrectice.Data;
using WebAPIPrectice.Models;

namespace WebAPIPrectice.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductsController : ControllerBase
{
    private readonly WebAPIContext _context;

    public ProductsController(WebAPIContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<List<Product>> Get()
    {
        return await _context.Products.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetProduct(int id)
    {
        Product product = await _context.Products.FindAsync(id);
        if (product == null)
        {
            return NotFound();
        }
        return Ok(product);
    }
}