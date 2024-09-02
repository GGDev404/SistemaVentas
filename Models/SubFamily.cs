using System;
using System.Collections.Generic;

namespace Sales_System_Api.Models;

public partial class SubFamily
{
    public int SubFamilyId { get; set; }

    public int? FamilyId { get; set; }

    public bool? IsJewel { get; set; }

    public DateTime? CreationDate { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public string? Status { get; set; }

    public bool? IsActive { get; set; }

    public virtual Family? Family { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
