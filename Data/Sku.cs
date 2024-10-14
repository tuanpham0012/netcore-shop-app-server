﻿using System;
using System.Collections.Generic;

namespace ShopAppApi.Data;

public partial class Sku
{
    public long Id { get; set; }

    public long ProductId { get; set; }

    public string BarCode { get; set; } = null!;

    public double Price { get; set; }

    public string Name { get; set; } = null!;

    public int Stock { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<Cart> Carts { get; set; } = [];

    public virtual ICollection<Discount> Discounts { get; set; } = [];

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = [];

    public virtual Product Product { get; set; } = null!;

    public virtual ICollection<Variant> Variants { get; set; } = [];
}
