using System;
using System.Collections.Generic;

namespace Sales_System_Api.Models;

public partial class Inventory
{
    public int InventoryId { get; set; }

    public int? ProductId { get; set; }

    public DateTime? EntryDate { get; set; }

    public decimal? Price { get; set; }

    public int? Quantity { get; set; }

    public int? BranchId { get; set; }

    public string? AcquisitionFolio { get; set; }

    public string? Invoice { get; set; }

    public string? Supplier { get; set; }

    public virtual Branch? Branch { get; set; }

    public virtual Product? Product { get; set; }
}
