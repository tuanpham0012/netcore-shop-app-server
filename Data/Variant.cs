using System;
using System.Collections.Generic;

namespace ShopAppApi.Data;

public partial class Variant
{
    public long Id { get; set; }

    public long ProductId { get; set; }

    public long SkuId { get; set; }

    public long OptionId { get; set; }

    public long OptionValueId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Option Option { get; set; } = null!;

    public virtual OptionValue OptionValue { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;

    public virtual Sku Sku { get; set; } = null!;
}
