public class CustomerDTO
{
    public int CustomerId { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
    public required string Phone { get; set; }
    public required string Mobile { get; set; }
    public required string Curp { get; set; }
    public required string Rfc { get; set; }
    public required string Ine { get; set; }
    public int? BranchCreationId { get; set; }
    public required string BranchCreationName { get; set; }
    public required string Gender { get; set; }
    public DateTime? BirthDate { get; set; }
    public required string CustomerOccupation { get; set; }
    public required string CivilStatus { get; set; }
    public required string Notes { get; set; }
}
