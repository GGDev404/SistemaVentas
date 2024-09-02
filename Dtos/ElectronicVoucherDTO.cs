public class ElectronicVoucherDTO
{
    public int ElectronicVoucherId { get; set; }
    public int CustomerId { get; set; }
    public decimal Amount { get; set; }
    public DateTime ExpiryDate { get; set; }
    public required string SecurityCode { get; set; }
    public bool IsTransferable { get; set; }
}
