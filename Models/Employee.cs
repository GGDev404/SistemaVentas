using System;
using System.Collections.Generic;

namespace Sales_System_Api.Models;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? Mobile { get; set; }

    public int? BranchId { get; set; }

    public string? Position { get; set; }

    public DateOnly? StartDate { get; set; }

    public bool? IsActive { get; set; }

    public virtual Branch? Branch { get; set; }

    public virtual ICollection<Branch> Branches { get; set; } = new List<Branch>();

    public virtual ICollection<CashRegisterAssignment> CashRegisterAssignments { get; set; } = new List<CashRegisterAssignment>();
}
