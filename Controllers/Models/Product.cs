using System.Text.Json.Serialization;

namespace WebAPIPrectice.Models;

public class Product
{
    public int Id { get; set; }

    public string Sku { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public Boolean IsAvailable { get; set; }

    [JsonIgnore]
    public string Category { get; set; }
}