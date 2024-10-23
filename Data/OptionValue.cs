using System;
using System.Collections.Generic;

namespace ShopAppApi.Data;

public partial class OptionValue
{
    public long Id { get; set; }

    public string? Code { get; set; }

    public long ProductId { get; set; }

    public long OptionId { get; set; }

    public string? Value { get; set; }

    public string? Label { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Option Option { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;

    public virtual ICollection<Variant> Variants { get; set; } = new List<Variant>();
}
