using System;
using System.Collections.Generic;

namespace Sales_System_Api.Models;

public partial class Branch
{
    public int BranchId { get; set; }

    public string Code { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? FiscalAddress { get; set; }

    public string? PhysicalAddress { get; set; }

    public string? Phone { get; set; }

    public int? ManagerId { get; set; }

    public virtual ICollection<CashRegister> CashRegisters { get; set; } = new List<CashRegister>();

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public virtual ICollection<Inventory> Inventories { get; set; } = new List<Inventory>();

    public virtual Employee? Manager { get; set; }

    public virtual ICollection<Transfer> TransferDestinationBranches { get; set; } = new List<Transfer>();

    public virtual ICollection<Transfer> TransferSourceBranches { get; set; } = new List<Transfer>();
}
