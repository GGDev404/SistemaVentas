using System;
using System.Collections.Generic;

namespace Sales_System_Api.Models;

public partial class CreditPayment
{
    public int CreditPaymentId { get; set; }

    public int? CreditSaleId { get; set; }

    public DateTime? PaymentDate { get; set; }

    public decimal? AmountPaid { get; set; }

    public decimal? LateFee { get; set; }

    public virtual CreditSale? CreditSale { get; set; }
    public decimal Amount { get; internal set; }
}
