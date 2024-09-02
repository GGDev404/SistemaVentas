using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging; // Agregar esta línea
using Stripe;
using Microsoft.EntityFrameworkCore;
using Sales_System_Api.Models;
using System.Text.Json;

[ApiController]
[Route("api/[controller]")]
public class CreateSaleController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<CreateSaleController> _logger; // Añadir un campo para ILogger

    public CreateSaleController(ApplicationDbContext context, ILogger<CreateSaleController> logger)
    {
        _context = context;
        _logger = logger; // Inicializar el logger
    }

   [HttpPost]
public async Task<IActionResult> CreateSale([FromBody] SaleDTO saleDto)
{
    _logger.LogInformation("Starting CreateSale process.");
    _logger.LogInformation($"Received SaleDTO: {JsonSerializer.Serialize(saleDto)}");

    // Validación de productos en inventario y cálculo del precio total
    decimal totalAmount = 0;
    foreach (var detailDto in saleDto.SaleDetails)
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

        totalAmount += (decimal)(inventoryItem.Price * detailDto.Quantity);
    }

    // Crear la venta
    var sale = new Sale
    {
        SaleDate = DateTime.Now,
        CustomerId = saleDto.CustomerId,
        TotalAmount = totalAmount,
        PaymentType = saleDto.PaymentType,
        StripePaymentReference = saleDto.StripePaymentReference,
    };

    _context.Sales.Add(sale);

    // Actualizar inventario y crear detalles de la venta
    foreach (var detailDto in saleDto.SaleDetails)
    {
        var inventoryItem = await _context.Inventories
            .FirstOrDefaultAsync(i => i.ProductId == detailDto.ProductId);

        if (inventoryItem != null)
        {
            inventoryItem.Quantity -= detailDto.Quantity;

            var saleDetail = new SaleDetail
            {
                Sale = sale,
                ProductId = detailDto.ProductId,
                Quantity = detailDto.Quantity,
                Price = inventoryItem.Price,
            };

            _context.SaleDetails.Add(saleDetail);
        }
    }

    // Procesar pago con tarjeta si es necesario
    if (saleDto.PaymentType == "Card")
    {
        _logger.LogInformation($"Processing Stripe payment with reference: {saleDto.StripePaymentReference} and amount: {totalAmount}");
        var paymentSuccess = await ProcessStripePayment(saleDto.StripePaymentReference, totalAmount);
        if (!paymentSuccess)
        {
            _logger.LogError("Payment processing failed.");
            return StatusCode(StatusCodes.Status500InternalServerError, "Payment processing failed.");
        }
    }

    await _context.SaveChangesAsync();

    _logger.LogInformation($"Sale created successfully with ID {sale.SaleId}.");
    return Ok(new { saleId = sale.SaleId });
}

private async Task<bool> ProcessStripePayment(string stripePaymentReference, decimal amount)
{
    try
    {
        var options = new PaymentIntentCreateOptions
        {
            Amount = (long)(amount * 100), // Convertir a centavos
            Currency = "mxn",
            PaymentMethod = stripePaymentReference, // Asegúrate de que este es el ID del método de pago
            ConfirmationMethod = "manual",
            Confirm = true,
            ReturnUrl = "http://localhost:4200/dashboard" // Cambia esta URL a la que quieres redirigir después del pago
        };

        var service = new PaymentIntentService();
        var intent = await service.CreateAsync(options);

        if (intent.Status == "succeeded")
        {
            return true;
        }
        else if (intent.Status == "requires_action" || intent.Status == "requires_source_action")
        {
            // Si el pago requiere autenticación, redirige al usuario a la URL de retorno para completar el pago
            return false; // En este caso, deberás manejar la redirección del cliente en el frontend
        }
        else
        {
            return false;
        }
    }
    catch (StripeException ex)
    {
        _logger.LogError(ex, "StripeException occurred while processing payment.");
        return false;
    }
    catch (Exception ex)
    {
        _logger.LogError(ex, "Exception occurred while processing payment.");
        return false;
    }
}

}
