using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Sales_System_Api.Models;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Branch> Branches { get; set; }

    public virtual DbSet<CashRegister> CashRegisters { get; set; }

    public virtual DbSet<CashRegisterAssignment> CashRegisterAssignments { get; set; }

    public virtual DbSet<CreditPayment> CreditPayments { get; set; }

    public virtual DbSet<CreditSale> CreditSales { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<ElectronicVoucher> ElectronicVouchers { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Family> Families { get; set; }

    public virtual DbSet<Inventory> Inventories { get; set; }

    public virtual DbSet<Layaway> Layaways { get; set; }

    public virtual DbSet<LayawayDetail> LayawayDetails { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Sale> Sales { get; set; }

    public virtual DbSet<SaleDetail> SaleDetails { get; set; }

    public virtual DbSet<ScheduledCreditPayment> ScheduledCreditPayments { get; set; }

    public virtual DbSet<ScheduledLayawayPayment> ScheduledLayawayPayments { get; set; }

    public virtual DbSet<SubFamily> SubFamilies { get; set; }

    public virtual DbSet<Transfer> Transfers { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Branch>(entity =>
        {
            entity.HasKey(e => e.BranchId).HasName("PK__Branch__A1682FC5BCF9022E");

            entity.ToTable("Branch");

            entity.Property(e => e.Code).HasMaxLength(10);
            entity.Property(e => e.FiscalAddress).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Phone).HasMaxLength(20);
            entity.Property(e => e.PhysicalAddress).HasMaxLength(255);

            entity.HasOne(d => d.Manager).WithMany(p => p.Branches)
                .HasForeignKey(d => d.ManagerId)
                .HasConstraintName("FK_Branch_Manager");
        });

        modelBuilder.Entity<CashRegister>(entity =>
        {
            entity.HasKey(e => e.CashRegisterId).HasName("PK__CashRegi__7B5CAE9478EC971C");

            entity.ToTable("CashRegister");

            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.InventoryNumber).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.SerialNumber).HasMaxLength(50);
            entity.Property(e => e.Status).HasMaxLength(20);

            entity.HasOne(d => d.Branch).WithMany(p => p.CashRegisters)
                .HasForeignKey(d => d.BranchId)
                .HasConstraintName("FK__CashRegis__Branc__3C69FB99");
        });

        modelBuilder.Entity<CashRegisterAssignment>(entity =>
        {
            entity.HasKey(e => e.CashRegisterAssignmentId).HasName("PK__CashRegi__38D5565BB432D947");

            entity.ToTable("CashRegisterAssignment");

            entity.HasOne(d => d.CashRegister).WithMany(p => p.CashRegisterAssignments)
                .HasForeignKey(d => d.CashRegisterId)
                .HasConstraintName("FK__CashRegis__CashR__3F466844");

            entity.HasOne(d => d.Employee).WithMany(p => p.CashRegisterAssignments)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK__CashRegis__Emplo__403A8C7D");
        });

        modelBuilder.Entity<CreditPayment>(entity =>
        {
            entity.HasKey(e => e.CreditPaymentId).HasName("PK__CreditPa__3C85B75341E2C066");

            entity.ToTable("CreditPayment");

            entity.Property(e => e.AmountPaid).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.LateFee).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.PaymentDate).HasColumnType("datetime");

            entity.HasOne(d => d.CreditSale).WithMany(p => p.CreditPayments)
                .HasForeignKey(d => d.CreditSaleId)
                .HasConstraintName("FK__CreditPay__Credi__6D0D32F4");
        });

        modelBuilder.Entity<CreditSale>(entity =>
        {
            entity.HasKey(e => e.CreditSaleId).HasName("PK__CreditSa__91BA63860DE92BF8");

            entity.ToTable("CreditSale");

            entity.Property(e => e.DownPayment).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.InterestRate).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.StartDate).HasColumnType("datetime");
            entity.Property(e => e.StripePaymentReference).HasMaxLength(255);
            entity.Property(e => e.TotalCredit).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Customer).WithMany(p => p.CreditSales)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK__CreditSal__Custo__6A30C649");

            entity.HasOne(d => d.Sale).WithMany(p => p.CreditSales)
                .HasForeignKey(d => d.SaleId)
                .HasConstraintName("FK__CreditSal__SaleI__693CA210");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__Customer__A4AE64D87C737727");

            entity.ToTable("Customer");

            entity.Property(e => e.BranchCreationName).HasMaxLength(100);
            entity.Property(e => e.CivilStatus).HasMaxLength(50);
            entity.Property(e => e.Curp).HasMaxLength(20);
            entity.Property(e => e.CustomerOccupation).HasMaxLength(100);
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.FirstName).HasMaxLength(255);
            entity.Property(e => e.Gender).HasMaxLength(20);
            entity.Property(e => e.Ine).HasMaxLength(20);
            entity.Property(e => e.LastName).HasMaxLength(100);
            entity.Property(e => e.Mobile).HasMaxLength(20);
            entity.Property(e => e.Notes).HasMaxLength(255);
            entity.Property(e => e.Phone).HasMaxLength(20);
            entity.Property(e => e.Rfc).HasMaxLength(20);

            entity.HasOne(d => d.BranchCreation).WithMany(p => p.Customers)
                .HasForeignKey(d => d.BranchCreationId)
                .HasConstraintName("FK__Customer__Branch__4316F928");
        });

        modelBuilder.Entity<ElectronicVoucher>(entity =>
        {
            entity.HasKey(e => e.ElectronicVoucherId).HasName("PK__Electron__1B605C2F4224C776");

            entity.ToTable("ElectronicVoucher");

            entity.Property(e => e.Amount).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ExpiryDate).HasColumnType("datetime");
            entity.Property(e => e.SecurityCode).HasMaxLength(50);

            entity.HasOne(d => d.Customer).WithMany(p => p.ElectronicVouchers)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK__Electroni__Custo__66603565");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PK__Employee__7AD04F11FD4FC685");

            entity.ToTable("Employee");

            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.FirstName).HasMaxLength(255);
            entity.Property(e => e.LastName).HasMaxLength(100);
            entity.Property(e => e.Mobile).HasMaxLength(20);
            entity.Property(e => e.Phone).HasMaxLength(20);
            entity.Property(e => e.Position).HasMaxLength(100);

            entity.HasOne(d => d.Branch).WithMany(p => p.Employees)
                .HasForeignKey(d => d.BranchId)
                .HasConstraintName("FK__Employee__Branch__38996AB5");
        });

        modelBuilder.Entity<Family>(entity =>
        {
            entity.HasKey(e => e.FamilyId).HasName("PK__Family__41D82F6BD55A321E");

            entity.ToTable("Family");

            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Status).HasMaxLength(20);
        });

        modelBuilder.Entity<Inventory>(entity =>
        {
            entity.HasKey(e => e.InventoryId).HasName("PK__Inventor__F5FDE6B37E9DD6CA");

            entity.ToTable("Inventory");

            entity.Property(e => e.AcquisitionFolio).HasMaxLength(50);
            entity.Property(e => e.EntryDate).HasColumnType("datetime");
            entity.Property(e => e.Invoice).HasMaxLength(50);
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Supplier).HasMaxLength(100);

            entity.HasOne(d => d.Branch).WithMany(p => p.Inventories)
                .HasForeignKey(d => d.BranchId)
                .HasConstraintName("FK__Inventory__Branc__4E88ABD4");

            entity.HasOne(d => d.Product).WithMany(p => p.Inventories)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__Inventory__Produ__4D94879B");
        });

        modelBuilder.Entity<Layaway>(entity =>
        {
            entity.HasKey(e => e.LayawayId).HasName("PK__Layaway__5B5668CB49F63707");

            entity.ToTable("Layaway");

            entity.Property(e => e.DownPayment).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.LayawayDate).HasColumnType("datetime");
            entity.Property(e => e.TotalAmount).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Customer).WithMany(p => p.Layaways)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK__Layaway__Custome__5812160E");
        });

        modelBuilder.Entity<LayawayDetail>(entity =>
        {
            entity.HasKey(e => e.LayawayDetailId).HasName("PK__LayawayD__79E9820510D67F53");

            entity.ToTable("LayawayDetail");

            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Layaway).WithMany(p => p.LayawayDetails)
                .HasForeignKey(d => d.LayawayId)
                .HasConstraintName("FK__LayawayDe__Layaw__5AEE82B9");

            entity.HasOne(d => d.Product).WithMany(p => p.LayawayDetails)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__LayawayDe__Produ__5BE2A6F2");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.PaymentId).HasName("PK__Payment__9B556A38013462C2");

            entity.ToTable("Payment");

            entity.Property(e => e.Amount).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Concept).HasMaxLength(100);
            entity.Property(e => e.PaymentDate).HasColumnType("datetime");
            entity.Property(e => e.PaymentType).HasMaxLength(50);
            entity.Property(e => e.StripePaymentReference).HasMaxLength(255);

            entity.HasOne(d => d.Customer).WithMany(p => p.Payments)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK__Payment__Custome__5EBF139D");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Product__B40CC6CDDEEDFB15");

            entity.ToTable("Product");

            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.ImageUrl).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Status).HasMaxLength(20);

            entity.HasOne(d => d.SubFamily).WithMany(p => p.Products)
                .HasForeignKey(d => d.SubFamilyId)
                .HasConstraintName("FK__Product__SubFami__4AB81AF0");
        });

        modelBuilder.Entity<Sale>(entity =>
        {
            entity.HasKey(e => e.SaleId).HasName("PK__Sale__1EE3C3FF3C4603D6");

            entity.ToTable("Sale");

            entity.Property(e => e.PaymentType).HasMaxLength(50);
            entity.Property(e => e.SaleDate).HasColumnType("datetime");
            entity.Property(e => e.StripePaymentReference).HasMaxLength(255);
            entity.Property(e => e.TotalAmount).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Customer).WithMany(p => p.Sales)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK__Sale__CustomerId__5165187F");
        });

        modelBuilder.Entity<SaleDetail>(entity =>
        {
            entity.HasKey(e => e.SaleDetailId).HasName("PK__SaleDeta__70DB14FE0D6D2754");

            entity.ToTable("SaleDetail");

            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Product).WithMany(p => p.SaleDetails)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__SaleDetai__Produ__5535A963");

            entity.HasOne(d => d.Sale).WithMany(p => p.SaleDetails)
                .HasForeignKey(d => d.SaleId)
                .HasConstraintName("FK__SaleDetai__SaleI__5441852A");
        });

        modelBuilder.Entity<ScheduledCreditPayment>(entity =>
        {
            entity.HasKey(e => e.ScheduledCreditPaymentId).HasName("PK__Schedule__5AA454D392D3A303");

            entity.ToTable("ScheduledCreditPayment");

            entity.Property(e => e.Amount).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.CreditSale).WithMany(p => p.ScheduledCreditPayments)
                .HasForeignKey(d => d.CreditSaleId)
                .HasConstraintName("FK__Scheduled__Credi__72C60C4A");
        });

        modelBuilder.Entity<ScheduledLayawayPayment>(entity =>
        {
            entity.HasKey(e => e.ScheduledLayawayPaymentId).HasName("PK__Schedule__40A22A3CBCD4148E");

            entity.ToTable("ScheduledLayawayPayment");

            entity.Property(e => e.Amount).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Layaway).WithMany(p => p.ScheduledLayawayPayments)
                .HasForeignKey(d => d.LayawayId)
                .HasConstraintName("FK__Scheduled__Layaw__6FE99F9F");
        });

        modelBuilder.Entity<SubFamily>(entity =>
        {
            entity.HasKey(e => e.SubFamilyId).HasName("PK__SubFamil__7767F330700D179B");

            entity.ToTable("SubFamily");

            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Status).HasMaxLength(20);

            entity.HasOne(d => d.Family).WithMany(p => p.SubFamilies)
                .HasForeignKey(d => d.FamilyId)
                .HasConstraintName("FK__SubFamily__Famil__47DBAE45");
        });

        modelBuilder.Entity<Transfer>(entity =>
        {
            entity.HasKey(e => e.TransferId).HasName("PK__Transfer__95490091335288E9");

            entity.ToTable("Transfer");

            entity.Property(e => e.Observations).HasMaxLength(255);
            entity.Property(e => e.TransferDate).HasColumnType("datetime");

            entity.HasOne(d => d.DestinationBranch).WithMany(p => p.TransferDestinationBranches)
                .HasForeignKey(d => d.DestinationBranchId)
                .HasConstraintName("FK__Transfer__Destin__6383C8BA");

            entity.HasOne(d => d.Product).WithMany(p => p.Transfers)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__Transfer__Produc__619B8048");

            entity.HasOne(d => d.SourceBranch).WithMany(p => p.TransferSourceBranches)
                .HasForeignKey(d => d.SourceBranchId)
                .HasConstraintName("FK__Transfer__Source__628FA481");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
