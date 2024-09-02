public class EmployeeDTO
{
    public int EmployeeId { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
    public required string Phone { get; set; }
    public required string Mobile { get; set; }
    public int BranchId { get; set; }
    public required string Position { get; set; }
    public DateTime? StartDate { get; set; }
    public bool IsActive { get; set; }
}
