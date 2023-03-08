namespace WebAPIPrectice.Models;

public partial class ProductsQueryParameters : QueryParameters
{
    public double? MaxPrice { get; set; }
    public double? MinPrice { get; set; }

    public string? Name { get; set; }
    public string? Sku { get; set; }
}

