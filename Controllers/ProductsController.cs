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
    public async Task<ActionResult> Get([FromQuery] ProductsQueryParameters queryParameters)
    {
        IQueryable<Product> products = _context.Products;
        if (queryParameters.MinPrice != null)
        {
            products = products.Where(x => x.Price >= queryParameters.MinPrice);
        }

        if (queryParameters.MaxPrice != null)
        {
            products = products.Where(x => x.Price <= queryParameters.MaxPrice);
        }

        if (queryParameters.Name != null)
        {
            products = products.Where(x => x.Name.ToLower().Contains(queryParameters.Name.ToLower()));
        }

        if (queryParameters.Sku != null)
        {
            products = products.Where(x => x.Sku.ToLower().Contains(queryParameters.Sku.ToLower()));
        }

        if (queryParameters.orderBy != null)
        {
            if (typeof(Product).GetProperty(queryParameters.orderBy) != null)
            {
                products = products.OrderByCustom(queryParameters.orderBy, queryParameters.sortOrder);
            }
        }
        if (queryParameters.SearchTerm != null)
        {
            products = products.Where(x => x.Name.ToLower().Contains(queryParameters.SearchTerm.ToLower())
            || x.Sku.ToLower().Contains(queryParameters.SearchTerm.ToLower()));
        }

        products = products.Skip((queryParameters.PageNumber - 1) * queryParameters.PageSize)
            .Take(queryParameters.PageSize);


        return Ok(await products.ToArrayAsync());
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

    [HttpPost]
    public async Task<ActionResult> PostProduct(Product product)
    {
        if (product == null)
        {
            return BadRequest();
        }

        _context.Products.Add(product);
        await _context.SaveChangesAsync();
        return Ok(product);
    }

    [HttpPut]
    public async Task<ActionResult> PutProduct(Product product)
    {
        if (product == null)
        {
            return BadRequest();
        }

        if (!_context.Products.Any(x => x.Id == product.Id))
        {
            return NotFound();
        }

        _context.Update(product);
        await _context.SaveChangesAsync();
        return Ok(product);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteProduct(int id)
    {
        Product product = _context.Products.FirstOrDefault(x => x.Id == id);
        if (product == null)
        {
            return NotFound();
        }

        _context.Products.Remove(product);
        await _context.SaveChangesAsync();
        return Ok(product);
    }

    [HttpPost]
    [Route("delete")]
    public async Task<ActionResult> DeleteProducts([FromQuery] int[] ids)
    {
        List<Product> products = _context.Products.Where(x => ids.Contains(x.Id)).ToList();
        if (products == null)
        {
            return BadRequest();
        }

        _context.Products.RemoveRange(products);
        await _context.SaveChangesAsync();
        return Ok(products);
    }
}