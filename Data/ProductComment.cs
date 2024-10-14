using System;
using System.Collections.Generic;

namespace ShopAppApi.Data;

public partial class ProductComment
{
    public long Id { get; set; }

    public long ProductId { get; set; }

    public int Rate { get; set; }

    public string? Comment { get; set; }

    public long? ParentId { get; set; }

    public string? Email { get; set; }

    public string? Name { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Product Product { get; set; } = null!;
}
