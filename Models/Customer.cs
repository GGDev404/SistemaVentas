using System;
using System.Collections.Generic;

namespace Sales_System_Api.Models;

public partial class Customer
{
    public int CustomerId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? Mobile { get; set; }

    public string? Curp { get; set; }

    public string? Rfc { get; set; }

    public string? Ine { get; set; }

    public int? BranchCreationId { get; set; }

    public string? BranchCreationName { get; set; }

    public string? Gender { get; set; }

    public DateOnly? BirthDate { get; set; }

    public string? CustomerOccupation { get; set; }

    public string? CivilStatus { get; set; }

    public string? Notes { get; set; }

    public virtual Branch? BranchCreation { get; set; }

    public virtual ICollection<CreditSale> CreditSales { get; set; } = new List<CreditSale>();

    public virtual ICollection<ElectronicVoucher> ElectronicVouchers { get; set; } = new List<ElectronicVoucher>();

    public virtual ICollection<Layaway> Layaways { get; set; } = new List<Layaway>();

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
}
