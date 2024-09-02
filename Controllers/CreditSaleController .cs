using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Sales_System_Api.Models;
using Sales_System_Api.Dtos;
using Microsoft.EntityFrameworkCore;


namespace Sales_System_Api.Controllers
{
    [ApiController]
[Route("api/[controller]")]
public class CreditSaleController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<CreditSaleController> _logger;

    public CreditSaleController(ApplicationDbContext context, ILogger<CreditSaleController> logger)
    {
        _context = context;
        _logger = logger;
    }

    // POST: api/CreditSale
    [HttpPost]
    public async Task<IActionResult> CreateCreditSale([FromBody] CreditSaleDTO creditSaleDto)
    {
        _logger.LogInformation("Starting CreateCreditSale process.");
        _logger.LogInformation($"Received CreditSaleDTO: {JsonSerializer.Serialize(creditSaleDto)}");

        // Validación de productos en inventario y cálculo del precio total
        decimal totalAmount = 0;
        foreach (var detailDto in creditSaleDto.SaleDetails)
        {
            _logger.LogInformation($"Checking inventory for ProductId: {detailDto.ProductId}");

            var inventoryItem = await _context.Inventories
                .FirstOrDefaultAsync(i => i.ProductId == detailDto.ProductId);

            if (inventoryItem == null)
            {
                _logger.LogWarning($"Inventory item with Product ID {detailDto.ProductId} not found.");
                return NotFound($"Inventory item with Product ID {detailDto.ProductId} not found in the branch.");
            }

            if (inventoryItem.Quantity < detailDto.Quantity)
            {
                _logger.LogWarning($"Insufficient quantity for product with ID {detailDto.ProductId}.");
                return BadRequest($"Insufficient quantity for product with ID {detailDto.ProductId}.");
            }

            totalAmount += detailDto.Price * detailDto.Quantity;
        }

        if (totalAmount != creditSaleDto.TotalAmount)
        {
            _logger.LogWarning("Total amount does not match calculated total.");
            return BadRequest("Total amount does not match the calculated total.");
        }

        // Crear la venta a crédito
        var creditSale = new CreditSale
        {
            SaleDate = DateTime.Now,
            CustomerId = creditSaleDto.CustomerId,
            TotalAmount = totalAmount,
            RemainingAmount = totalAmount,
            PaymentType = "Credit",
            Installments = creditSaleDto.Installments,
            FirstDueDate = creditSaleDto.FirstDueDate
        };

        _context.CreditSales.Add(creditSale);

        // Actualizar inventario y crear detalles de la venta
        foreach (var detailDto in creditSaleDto.SaleDetails)
        {
            var inventoryItem = await _context.Inventories
                .FirstOrDefaultAsync(i => i.ProductId == detailDto.ProductId);

            if (inventoryItem != null)
            {
                inventoryItem.Quantity -= detailDto.Quantity;

                var saleDetail = new SaleDetail
                {
                    Sale = creditSale,
                    ProductId = detailDto.ProductId,
                    Quantity = detailDto.Quantity,
                    Price = detailDto.Price,
                };

                _context.SaleDetails.Add(saleDetail);
            }
        }

        await _context.SaveChangesAsync();

        _logger.LogInformation($"Credit sale created successfully with ID {creditSale.SaleId}.");
        return Ok(new { saleId = creditSale.SaleId });
    }

    // POST: api/CreditSale/MakePayment
    [HttpPost("MakePayment")]
    public async Task<IActionResult> MakePayment([FromBody] CreditPaymentDTO paymentDto)
    {
        _logger.LogInformation("Starting MakePayment process.");

        var creditSale = await _context.CreditSales
            .FirstOrDefaultAsync(s => s.SaleId == paymentDto.CreditSaleId);

        if (creditSale == null)
        {
            _logger.LogWarning($"Credit sale with ID {paymentDto.CreditSaleId} not found.");
            return NotFound($"Credit sale with ID {paymentDto.CreditSaleId} not found.");
        }

        if (paymentDto.AmountPaid <= 0 || paymentDto.AmountPaid > creditSale.RemainingAmount)
        {
            _logger.LogWarning("Invalid payment amount.");
            return BadRequest("Invalid payment amount.");
        }

        creditSale.RemainingAmount -= paymentDto.Amount;

        var payment = new CreditPayment
        {
            CreditSaleId = paymentDto.CreditSaleId,
            PaymentDate = DateTime.Now,
            Amount = paymentDto.Amount
        };

        _context.CreditPayments.Add(payment);

        if (creditSale.RemainingAmount == 0)
        {
            _logger.LogInformation("Credit sale has been fully paid.");
        }

        await _context.SaveChangesAsync();

        _logger.LogInformation($"Payment of {paymentDto.Amount} made successfully for CreditSale ID {creditSale.SaleId}.");
        return Ok(new { saleId = creditSale.SaleId, remainingAmount = creditSale.RemainingAmount });
    }
}

}