using WebAPIPrectice.Models;

namespace WebAPIPrectice.Controllers;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<Product> Products { get; set; }
}