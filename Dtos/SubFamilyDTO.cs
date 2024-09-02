public class SubFamilyDTO
{
    public int SubFamilyId { get; set; }
    public int FamilyId { get; set; }
    public bool IsJewel { get; set; }
    public DateTime CreationDate { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required string Status { get; set; }
    public bool IsActive { get; set; }
}
