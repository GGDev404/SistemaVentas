public class InventoryDTO
{
    public int InventoryId { get; set; }
    public int ProductId { get; set; }
    public DateTime EntryDate { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public int BranchId { get; set; }
    public required string AcquisitionFolio { get; set; }
    public required string Invoice { get; set; }
    public required string Supplier { get; set; }
}
