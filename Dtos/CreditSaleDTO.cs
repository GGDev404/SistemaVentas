public class CreditSaleDTO
{
    public int CustomerId { get; set; }
    public string PaymentType { get; set; } = "Credit"; // El tipo de pago siempre será "Credit"
    public decimal TotalAmount { get; set; }
    public int Installments { get; set; } // Número de cuotas
    public DateTime FirstDueDate { get; set; } // Fecha de vencimiento de la primera cuota
    public IEnumerable<SaleDetailDTO> SaleDetails { get; set; }
}
