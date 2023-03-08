using System;
using System.Collections.Generic;

namespace WebAPIPrectice.Models;

public partial class Product
{
    public int Id { get; set; }

    public int? CategoryId { get; set; }

    public string? Name { get; set; }

    public string? Sku { get; set; }

    public double? Price { get; set; }

    public bool? IsAvailable { get; set; }
}
