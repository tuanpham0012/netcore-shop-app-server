using System;
using System.Collections.Generic;

namespace ShopAppApi.Data;

public partial class OrderDetail
{
    public long Id { get; set; }

    public long ProductId { get; set; }

    public long SkuId { get; set; }

    public double UnitPrice { get; set; }

    public int Quantity { get; set; }

    public double TotalAmount { get; set; }

    public double DiscountAmount { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual Sku Sku { get; set; } = null!;
}
