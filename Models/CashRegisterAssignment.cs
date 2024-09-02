using System;
using System.Collections.Generic;

namespace Sales_System_Api.Models;

public partial class CashRegisterAssignment
{
    public int CashRegisterAssignmentId { get; set; }

    public int? CashRegisterId { get; set; }

    public int? EmployeeId { get; set; }

    public DateOnly? AssignmentDate { get; set; }

    public virtual CashRegister? CashRegister { get; set; }

    public virtual Employee? Employee { get; set; }
}
