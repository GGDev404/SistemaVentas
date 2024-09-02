using System;
using System.Collections.Generic;

namespace Sales_System_Api.Models;

public partial class CreditSale
{
    public int CreditSaleId { get; set; }

    public int? SaleId { get; set; }

    public int? CustomerId { get; set; }

    public decimal? TotalCredit { get; set; }

    public decimal? DownPayment { get; set; }

    public int? TermMonths { get; set; }

    public decimal? InterestRate { get; set; }

    public DateTime? StartDate { get; set; }

    public string? StripePaymentReference { get; set; }

    public virtual ICollection<CreditPayment> CreditPayments { get; set; } = new List<CreditPayment>();

    public virtual Customer? Customer { get; set; }

    public virtual Sale? Sale { get; set; }

    public virtual ICollection<ScheduledCreditPayment> ScheduledCreditPayments { get; set; } = new List<ScheduledCreditPayment>();
    public DateTime SaleDate { get; internal set; }
    public decimal TotalAmount { get; internal set; }
    public decimal RemainingAmount { get; internal set; }
    public string PaymentType { get; internal set; }
    public int Installments { get; internal set; }
    public DateTime FirstDueDate { get; internal set; }
}
