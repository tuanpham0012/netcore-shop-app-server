﻿using System;
using System.Collections.Generic;

namespace ShopAppApi.Data;

public partial class Migration
{
    public int Id { get; set; }

    public string Migration1 { get; set; } = null!;

    public int Batch { get; set; }
}
