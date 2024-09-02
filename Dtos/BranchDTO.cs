public class BranchDTO
{
    public int BranchId { get; set; }
    public required string Code { get; set; }
    public required string Name { get; set; }
    public required string FiscalAddress { get; set; }
    public required string PhysicalAddress { get; set; }
    public required string Phone { get; set; }
    public int? ManagerId { get; set; }
}
