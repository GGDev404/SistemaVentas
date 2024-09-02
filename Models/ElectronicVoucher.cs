using System;
using System.Collections.Generic;

namespace Sales_System_Api.Models;

public partial class ElectronicVoucher
{
    public int ElectronicVoucherId { get; set; }

    public int? CustomerId { get; set; }

    public decimal? Amount { get; set; }

    public DateTime? ExpiryDate { get; set; }

    public string? SecurityCode { get; set; }

    public bool? IsTransferable { get; set; }

    public virtual Customer? Customer { get; set; }
}
