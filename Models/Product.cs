using System;
using System.Collections.Generic;

namespace Sales_System_Api.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public bool? IsJewel { get; set; }

    public int? SubFamilyId { get; set; }

    public DateTime? CreationDate { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public string? Status { get; set; }

    public bool? IsActive { get; set; }

    public string? ImageUrl { get; set; }

    public virtual ICollection<Inventory> Inventories { get; set; } = new List<Inventory>();

    public virtual ICollection<LayawayDetail> LayawayDetails { get; set; } = new List<LayawayDetail>();

    public virtual ICollection<SaleDetail> SaleDetails { get; set; } = new List<SaleDetail>();

    public virtual SubFamily? SubFamily { get; set; }

    public virtual ICollection<Transfer> Transfers { get; set; } = new List<Transfer>();
}
