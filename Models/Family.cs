using System;
using System.Collections.Generic;

namespace Sales_System_Api.Models;

public partial class Family
{
    public int FamilyId { get; set; }

    public bool? IsJewel { get; set; }

    public DateTime? CreationDate { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public string? Status { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<SubFamily> SubFamilies { get; set; } = new List<SubFamily>();
}
