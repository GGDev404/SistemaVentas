using System;
using System.Collections.Generic;

namespace Sales_System_Api.Models;

public partial class Layaway
{
    public int LayawayId { get; set; }

    public int? CustomerId { get; set; }

    public DateTime? LayawayDate { get; set; }

    public decimal? TotalAmount { get; set; }

    public decimal? DownPayment { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual ICollection<LayawayDetail> LayawayDetails { get; set; } = new List<LayawayDetail>();

    public virtual ICollection<ScheduledLayawayPayment> ScheduledLayawayPayments { get; set; } = new List<ScheduledLayawayPayment>();
}
