public class ScheduledCreditPaymentDTO
{
    public int ScheduledCreditPaymentId { get; set; }
    public int CreditSaleId { get; set; }
    public DateTime DueDate { get; set; }
    public decimal Amount { get; set; }
    public bool IsPaid { get; set; }
}
