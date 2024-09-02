using System;
using System.Collections.Generic;

namespace Sales_System_Api.Models;

public partial class ScheduledLayawayPayment
{
    public int ScheduledLayawayPaymentId { get; set; }

    public int? LayawayId { get; set; }

    public DateOnly? DueDate { get; set; }

    public decimal? Amount { get; set; }

    public bool? IsPaid { get; set; }

    public virtual Layaway? Layaway { get; set; }
}
