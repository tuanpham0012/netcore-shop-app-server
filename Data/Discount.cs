using System;
using System.Collections.Generic;

namespace ShopAppApi.Data;

public partial class Discount
{
    public long Id { get; set; }

    public long ProductId { get; set; }

    public long SkuId { get; set; }

    public double Discount1 { get; set; }

    public DateOnly? StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual Sku Sku { get; set; } = null!;
}
