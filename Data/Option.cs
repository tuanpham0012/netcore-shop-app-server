using System;
using System.Collections.Generic;

namespace ShopAppApi.Data;

public partial class Option
{
    public long Id { get; set; }

    public string? Code { get; set; }

    public long ProductId { get; set; }

    public string Name { get; set; } = null!;

    public byte Visual { get; set; }

    public byte Order { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<OptionValue> OptionValues { get; set; } = new List<OptionValue>();

    public virtual Product Product { get; set; } = null!;

    public virtual ICollection<Variant> Variants { get; set; } = new List<Variant>();
}
