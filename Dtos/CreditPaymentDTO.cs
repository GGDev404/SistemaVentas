public class CreditPaymentDTO
{
    public int CreditPaymentId { get; set; }
    public int CreditSaleId { get; set; }
    public DateTime PaymentDate { get; set; }
    public decimal AmountPaid { get; set; }
    public decimal LateFee { get; set; }
    public decimal Amount { get; internal set; }
}
