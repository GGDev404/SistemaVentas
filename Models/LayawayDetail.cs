using System;
using System.Collections.Generic;

namespace Sales_System_Api.Models;

public partial class LayawayDetail
{
    public int LayawayDetailId { get; set; }

    public int? LayawayId { get; set; }

    public int? ProductId { get; set; }

    public int? Quantity { get; set; }

    public decimal? Price { get; set; }

    public virtual Layaway? Layaway { get; set; }

    public virtual Product? Product { get; set; }
}
