using System;
using System.Collections.Generic;

namespace ShopAppApi.Data;

public partial class ProductStatistic
{
    public long Id { get; set; }

    public long ProductId { get; set; }

    public int ViewCount { get; set; }

    public int RateCount { get; set; }

    public int SoldCount { get; set; }

    public int CommentCount { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Product Product { get; set; } = null!;
}
