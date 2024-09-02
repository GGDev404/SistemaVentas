public class ScheduledLayawayPaymentDTO
{
    public int ScheduledLayawayPaymentId { get; set; }
    public int LayawayId { get; set; }
    public DateTime DueDate { get; set; }
    public decimal Amount { get; set; }
    public bool IsPaid { get; set; }
}
