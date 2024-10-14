﻿using System;
using System.Collections.Generic;

namespace ShopAppApi.Data;

public partial class Supplier
{
    public long Id { get; set; }

    public string Code { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Address { get; set; }

    public string? Phone { get; set; }

    public string Email { get; set; } = null!;

    public string? Logo { get; set; }

    public string? TaxCode { get; set; }

    public string? Description { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
