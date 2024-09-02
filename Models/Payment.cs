using System;
using System.Collections.Generic;

namespace Sales_System_Api.Models;

public partial class Payment
{
    public int PaymentId { get; set; }

    public int? CustomerId { get; set; }

    public DateTime? PaymentDate { get; set; }

    public decimal? Amount { get; set; }

    public string? PaymentType { get; set; }

    public string? Concept { get; set; }

    public string? StripePaymentReference { get; set; }

    public virtual Customer? Customer { get; set; }
}
