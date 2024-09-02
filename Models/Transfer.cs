using System;
using System.Collections.Generic;

namespace Sales_System_Api.Models;

public partial class Transfer
{
    public int TransferId { get; set; }

    public int? ProductId { get; set; }

    public int? Quantity { get; set; }

    public int? SourceBranchId { get; set; }

    public int? DestinationBranchId { get; set; }

    public DateTime? TransferDate { get; set; }

    public string? Observations { get; set; }

    public virtual Branch? DestinationBranch { get; set; }

    public virtual Product? Product { get; set; }

    public virtual Branch? SourceBranch { get; set; }
}
