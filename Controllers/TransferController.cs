using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Sales_System_Api.Models;

namespace Sales_System_Api.Controllers
{
    [ApiController]
[Route("api/[controller]")]
public class TransferController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<TransferController> _logger;

    public TransferController(ApplicationDbContext context, ILogger<TransferController> logger)
    {
        _context = context;
        _logger = logger;
    }

    // POST: api/Transfer
    [HttpPost]
    public async Task<IActionResult> CreateTransfer([FromBody] TransferDTO transferDto)
    {
        _logger.LogInformation("Starting CreateTransfer process.");
        _logger.LogInformation($"Received TransferDTO: {JsonSerializer.Serialize(transferDto)}");

        // Validación de productos en inventario y cálculo de cantidades
        foreach (var productDto in transferDto.TransferProducts)
        {
            _logger.LogInformation($"Checking inventory for ProductId: {productDto.ProductId} in SourceBranchId: {transferDto.SourceBranchId}");

            var inventoryItem = await _context.Inventories
                .FirstOrDefaultAsync(i => i.ProductId == productDto.ProductId && i.BranchId == transferDto.SourceBranchId);

            if (inventoryItem == null)
            {
                _logger.LogWarning($"Inventory item with Product ID {productDto.ProductId} not found in source branch.");
                return NotFound($"Inventory item with Product ID {productDto.ProductId} not found in source branch.");
            }

            if (inventoryItem.Quantity < productDto.Quantity)
            {
                _logger.LogWarning($"Insufficient quantity for product with ID {productDto.ProductId} in source branch.");
                return BadRequest($"Insufficient quantity for product with ID {productDto.ProductId} in source branch.");
            }
        }

        // Crear el traslado
        var transfer = new Transfer
        {
            TransferDate = DateTime.Now,
            SourceBranchId = transferDto.SourceBranchId,
            DestinationBranchId = transferDto.DestinationBranchId
        };

        _context.Transfers.Add(transfer);

        // Actualizar inventario y crear detalles de traslado
        foreach (var productDto in transferDto.TransferProducts)
        {
            var sourceInventoryItem = await _context.Inventories
                .FirstOrDefaultAsync(i => i.ProductId == productDto.ProductId && i.BranchId == transferDto.SourceBranchId);

            if (sourceInventoryItem != null)
            {
                sourceInventoryItem.Quantity -= productDto.Quantity;

                var destinationInventoryItem = await _context.Inventories
                    .FirstOrDefaultAsync(i => i.ProductId == productDto.ProductId && i.BranchId == transferDto.DestinationBranchId);

                if (destinationInventoryItem == null)
                {
                    destinationInventoryItem = new Inventory
                    {
                        ProductId = productDto.ProductId,
                        BranchId = transferDto.DestinationBranchId,
                        Quantity = productDto.Quantity,
                        Price = sourceInventoryItem.Price, // Puedes ajustar según sea necesario
                        EntryDate = DateTime.Now
                    };
                    _context.Inventories.Add(destinationInventoryItem);
                }
                else
                {
                    destinationInventoryItem.Quantity += productDto.Quantity;
                }
            }
        }

        await _context.SaveChangesAsync();

        _logger.LogInformation($"Transfer created successfully with ID {transfer.TransferId}.");
        return Ok(new { transferId = transfer.TransferId });
    }
}

}