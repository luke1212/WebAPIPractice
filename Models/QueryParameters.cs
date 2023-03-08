namespace WebAPIPrectice.Models;

public partial class QueryParameters
{
    private const int maxPageSize = 3;
    private int _size = 1;

    public int PageNumber { get; set; } = 1;
    public int PageSize
    {
        get { return _size; }
        set { _size = (value > maxPageSize) ? maxPageSize : value; }
    }
    public string? SearchTerm { get; set; }
}