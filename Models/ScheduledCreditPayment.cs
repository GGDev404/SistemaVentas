using System;
using System.Collections.Generic;

namespace Sales_System_Api.Models;

public partial class ScheduledCreditPayment
{
    public int ScheduledCreditPaymentId { get; set; }

    public int? CreditSaleId { get; set; }

    public DateOnly? DueDate { get; set; }

    public decimal? Amount { get; set; }

    public bool? IsPaid { get; set; }

    public virtual CreditSale? CreditSale { get; set; }
}
