namespace WebAPIPrectice.Models;

public partial class ProductsQueryParameters : QueryParameters
{
    private string _sortOrder = "asc";
    public double? MaxPrice { get; set; }
    public double? MinPrice { get; set; }

    public string? Name { get; set; }
    public string? Sku { get; set; }

    public string orderBy { get; set; } = "Id";
    public string sortOrder
    {
        get { return _sortOrder; }
        set
        {
            if (value == "asc" || value == "desc")
            {
                _sortOrder = value;
            }
        }
    }
}

