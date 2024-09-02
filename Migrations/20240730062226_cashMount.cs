using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sales_System_Api.Migrations
{
    /// <inheritdoc />
    public partial class cashMount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Family",
                columns: table => new
                {
                    FamilyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsJewel = table.Column<bool>(type: "bit", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Family__41D82F6BD55A321E", x => x.FamilyId);
                });

            migrationBuilder.CreateTable(
                name: "SubFamily",
                columns: table => new
                {
                    SubFamilyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FamilyId = table.Column<int>(type: "int", nullable: true),
                    IsJewel = table.Column<bool>(type: "bit", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__SubFamil__7767F330700D179B", x => x.SubFamilyId);
                    table.ForeignKey(
                        name: "FK__SubFamily__Famil__47DBAE45",
                        column: x => x.FamilyId,
                        principalTable: "Family",
                        principalColumn: "FamilyId");
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsJewel = table.Column<bool>(type: "bit", nullable: true),
                    SubFamilyId = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Product__B40CC6CDDEEDFB15", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK__Product__SubFami__4AB81AF0",
                        column: x => x.SubFamilyId,
                        principalTable: "SubFamily",
                        principalColumn: "SubFamilyId");
                });

            migrationBuilder.CreateTable(
                name: "Branch",
                columns: table => new
                {
                    BranchId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FiscalAddress = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    PhysicalAddress = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    ManagerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Branch__A1682FC5BCF9022E", x => x.BranchId);
                });

            migrationBuilder.CreateTable(
                name: "CashRegister",
                columns: table => new
                {
                    CashRegisterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SerialNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    InventoryNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BranchId = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    InitialAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CurrentAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CashRegi__7B5CAE9478EC971C", x => x.CashRegisterId);
                    table.ForeignKey(
                        name: "FK__CashRegis__Branc__3C69FB99",
                        column: x => x.BranchId,
                        principalTable: "Branch",
                        principalColumn: "BranchId");
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Curp = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Rfc = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Ine = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    BranchCreationId = table.Column<int>(type: "int", nullable: true),
                    BranchCreationName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    BirthDate = table.Column<DateOnly>(type: "date", nullable: true),
                    CustomerOccupation = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CivilStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Customer__A4AE64D87C737727", x => x.CustomerId);
                    table.ForeignKey(
                        name: "FK__Customer__Branch__4316F928",
                        column: x => x.BranchCreationId,
                        principalTable: "Branch",
                        principalColumn: "BranchId");
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    BranchId = table.Column<int>(type: "int", nullable: true),
                    Position = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Employee__7AD04F11FD4FC685", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK__Employee__Branch__38996AB5",
                        column: x => x.BranchId,
                        principalTable: "Branch",
                        principalColumn: "BranchId");
                });

            migrationBuilder.CreateTable(
                name: "Inventory",
                columns: table => new
                {
                    InventoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    EntryDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: true),
                    BranchId = table.Column<int>(type: "int", nullable: true),
                    AcquisitionFolio = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Invoice = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Supplier = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Inventor__F5FDE6B37E9DD6CA", x => x.InventoryId);
                    table.ForeignKey(
                        name: "FK__Inventory__Branc__4E88ABD4",
                        column: x => x.BranchId,
                        principalTable: "Branch",
                        principalColumn: "BranchId");
                    table.ForeignKey(
                        name: "FK__Inventory__Produ__4D94879B",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "ProductId");
                });

            migrationBuilder.CreateTable(
                name: "Transfer",
                columns: table => new
                {
                    TransferId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: true),
                    SourceBranchId = table.Column<int>(type: "int", nullable: true),
                    DestinationBranchId = table.Column<int>(type: "int", nullable: true),
                    TransferDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Observations = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Transfer__95490091335288E9", x => x.TransferId);
                    table.ForeignKey(
                        name: "FK__Transfer__Destin__6383C8BA",
                        column: x => x.DestinationBranchId,
                        principalTable: "Branch",
                        principalColumn: "BranchId");
                    table.ForeignKey(
                        name: "FK__Transfer__Produc__619B8048",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "ProductId");
                    table.ForeignKey(
                        name: "FK__Transfer__Source__628FA481",
                        column: x => x.SourceBranchId,
                        principalTable: "Branch",
                        principalColumn: "BranchId");
                });

            migrationBuilder.CreateTable(
                name: "ElectronicVoucher",
                columns: table => new
                {
                    ElectronicVoucherId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    ExpiryDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    SecurityCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsTransferable = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Electron__1B605C2F4224C776", x => x.ElectronicVoucherId);
                    table.ForeignKey(
                        name: "FK__Electroni__Custo__66603565",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "CustomerId");
                });

            migrationBuilder.CreateTable(
                name: "Layaway",
                columns: table => new
                {
                    LayawayId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: true),
                    LayawayDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    TotalAmount = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    DownPayment = table.Column<decimal>(type: "decimal(10,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Layaway__5B5668CB49F63707", x => x.LayawayId);
                    table.ForeignKey(
                        name: "FK__Layaway__Custome__5812160E",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "CustomerId");
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    PaymentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: true),
                    PaymentDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    PaymentType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Concept = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    StripePaymentReference = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Payment__9B556A38013462C2", x => x.PaymentId);
                    table.ForeignKey(
                        name: "FK__Payment__Custome__5EBF139D",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "CustomerId");
                });

            migrationBuilder.CreateTable(
                name: "Sale",
                columns: table => new
                {
                    SaleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: true),
                    SaleDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    TotalAmount = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    PaymentType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    StripePaymentReference = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Sale__1EE3C3FF3C4603D6", x => x.SaleId);
                    table.ForeignKey(
                        name: "FK__Sale__CustomerId__5165187F",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "CustomerId");
                });

            migrationBuilder.CreateTable(
                name: "CashRegisterAssignment",
                columns: table => new
                {
                    CashRegisterAssignmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CashRegisterId = table.Column<int>(type: "int", nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: true),
                    AssignmentDate = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CashRegi__38D5565BB432D947", x => x.CashRegisterAssignmentId);
                    table.ForeignKey(
                        name: "FK__CashRegis__CashR__3F466844",
                        column: x => x.CashRegisterId,
                        principalTable: "CashRegister",
                        principalColumn: "CashRegisterId");
                    table.ForeignKey(
                        name: "FK__CashRegis__Emplo__403A8C7D",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "EmployeeId");
                });

            migrationBuilder.CreateTable(
                name: "LayawayDetail",
                columns: table => new
                {
                    LayawayDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LayawayId = table.Column<int>(type: "int", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(10,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__LayawayD__79E9820510D67F53", x => x.LayawayDetailId);
                    table.ForeignKey(
                        name: "FK__LayawayDe__Layaw__5AEE82B9",
                        column: x => x.LayawayId,
                        principalTable: "Layaway",
                        principalColumn: "LayawayId");
                    table.ForeignKey(
                        name: "FK__LayawayDe__Produ__5BE2A6F2",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "ProductId");
                });

            migrationBuilder.CreateTable(
                name: "ScheduledLayawayPayment",
                columns: table => new
                {
                    ScheduledLayawayPaymentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LayawayId = table.Column<int>(type: "int", nullable: true),
                    DueDate = table.Column<DateOnly>(type: "date", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    IsPaid = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Schedule__40A22A3CBCD4148E", x => x.ScheduledLayawayPaymentId);
                    table.ForeignKey(
                        name: "FK__Scheduled__Layaw__6FE99F9F",
                        column: x => x.LayawayId,
                        principalTable: "Layaway",
                        principalColumn: "LayawayId");
                });

            migrationBuilder.CreateTable(
                name: "CreditSale",
                columns: table => new
                {
                    CreditSaleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SaleId = table.Column<int>(type: "int", nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: true),
                    TotalCredit = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    DownPayment = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    TermMonths = table.Column<int>(type: "int", nullable: true),
                    InterestRate = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    StripePaymentReference = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CreditSa__91BA63860DE92BF8", x => x.CreditSaleId);
                    table.ForeignKey(
                        name: "FK__CreditSal__Custo__6A30C649",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "CustomerId");
                    table.ForeignKey(
                        name: "FK__CreditSal__SaleI__693CA210",
                        column: x => x.SaleId,
                        principalTable: "Sale",
                        principalColumn: "SaleId");
                });

            migrationBuilder.CreateTable(
                name: "SaleDetail",
                columns: table => new
                {
                    SaleDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SaleId = table.Column<int>(type: "int", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(10,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__SaleDeta__70DB14FE0D6D2754", x => x.SaleDetailId);
                    table.ForeignKey(
                        name: "FK__SaleDetai__Produ__5535A963",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "ProductId");
                    table.ForeignKey(
                        name: "FK__SaleDetai__SaleI__5441852A",
                        column: x => x.SaleId,
                        principalTable: "Sale",
                        principalColumn: "SaleId");
                });

            migrationBuilder.CreateTable(
                name: "CreditPayment",
                columns: table => new
                {
                    CreditPaymentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreditSaleId = table.Column<int>(type: "int", nullable: true),
                    PaymentDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    AmountPaid = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    LateFee = table.Column<decimal>(type: "decimal(10,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CreditPa__3C85B75341E2C066", x => x.CreditPaymentId);
                    table.ForeignKey(
                        name: "FK__CreditPay__Credi__6D0D32F4",
                        column: x => x.CreditSaleId,
                        principalTable: "CreditSale",
                        principalColumn: "CreditSaleId");
                });

            migrationBuilder.CreateTable(
                name: "ScheduledCreditPayment",
                columns: table => new
                {
                    ScheduledCreditPaymentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreditSaleId = table.Column<int>(type: "int", nullable: true),
                    DueDate = table.Column<DateOnly>(type: "date", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    IsPaid = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Schedule__5AA454D392D3A303", x => x.ScheduledCreditPaymentId);
                    table.ForeignKey(
                        name: "FK__Scheduled__Credi__72C60C4A",
                        column: x => x.CreditSaleId,
                        principalTable: "CreditSale",
                        principalColumn: "CreditSaleId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Branch_ManagerId",
                table: "Branch",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_CashRegister_BranchId",
                table: "CashRegister",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_CashRegisterAssignment_CashRegisterId",
                table: "CashRegisterAssignment",
                column: "CashRegisterId");

            migrationBuilder.CreateIndex(
                name: "IX_CashRegisterAssignment_EmployeeId",
                table: "CashRegisterAssignment",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditPayment_CreditSaleId",
                table: "CreditPayment",
                column: "CreditSaleId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditSale_CustomerId",
                table: "CreditSale",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditSale_SaleId",
                table: "CreditSale",
                column: "SaleId");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_BranchCreationId",
                table: "Customer",
                column: "BranchCreationId");

            migrationBuilder.CreateIndex(
                name: "IX_ElectronicVoucher_CustomerId",
                table: "ElectronicVoucher",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_BranchId",
                table: "Employee",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_BranchId",
                table: "Inventory",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_ProductId",
                table: "Inventory",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Layaway_CustomerId",
                table: "Layaway",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_LayawayDetail_LayawayId",
                table: "LayawayDetail",
                column: "LayawayId");

            migrationBuilder.CreateIndex(
                name: "IX_LayawayDetail_ProductId",
                table: "LayawayDetail",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_CustomerId",
                table: "Payment",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_SubFamilyId",
                table: "Product",
                column: "SubFamilyId");

            migrationBuilder.CreateIndex(
                name: "IX_Sale_CustomerId",
                table: "Sale",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleDetail_ProductId",
                table: "SaleDetail",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleDetail_SaleId",
                table: "SaleDetail",
                column: "SaleId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduledCreditPayment_CreditSaleId",
                table: "ScheduledCreditPayment",
                column: "CreditSaleId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduledLayawayPayment_LayawayId",
                table: "ScheduledLayawayPayment",
                column: "LayawayId");

            migrationBuilder.CreateIndex(
                name: "IX_SubFamily_FamilyId",
                table: "SubFamily",
                column: "FamilyId");

            migrationBuilder.CreateIndex(
                name: "IX_Transfer_DestinationBranchId",
                table: "Transfer",
                column: "DestinationBranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Transfer_ProductId",
                table: "Transfer",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Transfer_SourceBranchId",
                table: "Transfer",
                column: "SourceBranchId");

            migrationBuilder.AddForeignKey(
                name: "FK_Branch_Manager",
                table: "Branch",
                column: "ManagerId",
                principalTable: "Employee",
                principalColumn: "EmployeeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Branch_Manager",
                table: "Branch");

            migrationBuilder.DropTable(
                name: "CashRegisterAssignment");

            migrationBuilder.DropTable(
                name: "CreditPayment");

            migrationBuilder.DropTable(
                name: "ElectronicVoucher");

            migrationBuilder.DropTable(
                name: "Inventory");

            migrationBuilder.DropTable(
                name: "LayawayDetail");

            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.DropTable(
                name: "SaleDetail");

            migrationBuilder.DropTable(
                name: "ScheduledCreditPayment");

            migrationBuilder.DropTable(
                name: "ScheduledLayawayPayment");

            migrationBuilder.DropTable(
                name: "Transfer");

            migrationBuilder.DropTable(
                name: "CashRegister");

            migrationBuilder.DropTable(
                name: "CreditSale");

            migrationBuilder.DropTable(
                name: "Layaway");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Sale");

            migrationBuilder.DropTable(
                name: "SubFamily");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Family");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Branch");
        }
    }
}
