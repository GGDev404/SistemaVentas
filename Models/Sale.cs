using System;
using System.Collections.Generic;

namespace Sales_System_Api.Models;

public partial class Sale
{
    public int SaleId { get; set; }

    public int? CustomerId { get; set; }

    public DateTime? SaleDate { get; set; }

    public decimal? TotalAmount { get; set; }

    public string? PaymentType { get; set; }

    public string? StripePaymentReference { get; set; }

    public virtual ICollection<CreditSale> CreditSales { get; set; } = new List<CreditSale>();

    public virtual Customer? Customer { get; set; }

    public virtual ICollection<SaleDetail> SaleDetails { get; set; } = new List<SaleDetail>();

    public static implicit operator Sale(CreditSale v)
    {
        throw new NotImplementedException();
    }
}
