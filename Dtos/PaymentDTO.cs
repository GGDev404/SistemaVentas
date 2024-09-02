public class PaymentDTO
{
    public int PaymentId { get; set; }
    public int CustomerId { get; set; }
    public DateTime PaymentDate { get; set; }
    public decimal Amount { get; set; }
    public required string PaymentType { get; set; }
    public required string Concept { get; set; }
    public string? StripePaymentReference { get; set; }
}
