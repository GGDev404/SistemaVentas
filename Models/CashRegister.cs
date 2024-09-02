using System;
using System.Collections.Generic;

namespace Sales_System_Api.Models;

public partial class CashRegister
{
    public int CashRegisterId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public string? SerialNumber { get; set; }

    public string? InventoryNumber { get; set; }

    public int? BranchId { get; set; }

    public string? Status { get; set; }

    public bool? IsDeleted { get; set; }

    // Nueva propiedad para el monto inicial
    public decimal InitialAmount { get; set; }

    // Nueva propiedad para el monto generado
    public decimal GeneratedAmount { get; set; }

    public virtual Branch? Branch { get; set; }

    public virtual ICollection<CashRegisterAssignment> CashRegisterAssignments { get; set; } = new List<CashRegisterAssignment>();
}
