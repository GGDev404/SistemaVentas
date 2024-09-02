public class SaleDTO
{
    public int SaleId { get; set; }
    public int CustomerId { get; set; }
    public DateTime SaleDate { get; set; }
    public decimal TotalAmount { get; set; }
    public required string PaymentType { get; set; }
    public string? StripePaymentReference { get; set; }
    public List<SaleDetailDTO> SaleDetails { get; set; } = new List<SaleDetailDTO>();
}