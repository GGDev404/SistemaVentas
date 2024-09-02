    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Sales_System_Api.Models;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    namespace Sales_System_Api.Controllers
    {
        [Route("api/[controller]")]
        [ApiController]
        public class ProductController : ControllerBase
        {
            private readonly ApplicationDbContext _context;

            public ProductController(ApplicationDbContext context)
            {
                _context = context;
            }

            // GET: api/Product
            [HttpGet]
            public async Task<ActionResult<IEnumerable<ProductDTO>>> GetProducts()
            {
                var products = await _context.Products
                    .Include(p => p.SubFamily)
                    .Include(p => p.Inventories) // Include Inventories
                    .ToListAsync();

                var productDTOs = products.Select(p => new ProductDTO
                {
                    ProductId = p.ProductId,
                    IsJewel = (bool)p.IsJewel,
                    SubFamilyId = (int)p.SubFamilyId,
                    CreationDate = (DateTime)p.CreationDate,
                    Name = p.Name,
                    Description = p.Description,
                    Status = p.Status,
                    IsActive = (bool)p.IsActive,
                    ImageUrl = p.ImageUrl,
                    Price = p.Inventories.FirstOrDefault()?.Price ?? 0 // Get price from inventory
                }).ToList();

                return Ok(productDTOs);
            }

            // GET: api/Product/5
            [HttpGet("{id}")]
            public async Task<ActionResult<ProductDTO>> GetProduct(int id)
            {
                var product = await _context.Products
                    .Include(p => p.SubFamily)
                    .Include(p => p.Inventories) // Include Inventories
                    .FirstOrDefaultAsync(p => p.ProductId == id);

                if (product == null)
                {
                    return NotFound();
                }

                var productDTO = new ProductDTO
                {
                    ProductId = product.ProductId,
                    IsJewel = (bool)product.IsJewel,
                    SubFamilyId = (int)product.SubFamilyId,
                    CreationDate = (DateTime)product.CreationDate,
                    Name = product.Name,
                    ImageUrl = product.ImageUrl,
                    Description = product.Description,
                    Status = product.Status,
                    IsActive = (bool)product.IsActive,
                    
                    Price = product.Inventories.FirstOrDefault()?.Price ?? 0 // Get price from inventory
                };

                return Ok(productDTO);
            }

            // PUT: api/Product/5
            [HttpPut("{id}")]
            public async Task<IActionResult> PutProduct(int id, ProductDTO productDTO)
            {
                if (id != productDTO.ProductId)
                {
                    return BadRequest();
                }

                var product = await _context.Products.FindAsync(id);
                if (product == null)
                {
                    return NotFound();
                }

                product.IsJewel = productDTO.IsJewel;
                product.SubFamilyId = productDTO.SubFamilyId;
                product.CreationDate = productDTO.CreationDate;
                product.Name = productDTO.Name;
                product.Description = productDTO.Description;
                product.Status = productDTO.Status;
                product.IsActive = productDTO.IsActive;
                product.ImageUrl = productDTO.ImageUrl;
                _context.Entry(product).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return NoContent();
            }

            // POST: api/Product
            [HttpPost]
            public async Task<ActionResult<ProductDTO>> PostProduct([FromBody] ProductCreateDTO productCreateDto)
            {
                // Crear el producto
                var product = new Product
                {
                    IsJewel = productCreateDto.IsJewel,
                    SubFamilyId = productCreateDto.SubFamilyId,
                    CreationDate = productCreateDto.CreationDate,
                    Name = productCreateDto.Name,
                    Description = productCreateDto.Description,
                    Status = productCreateDto.Status,
                    IsActive = productCreateDto.IsActive,
                    ImageUrl = productCreateDto.ImageUrl
                };

                _context.Products.Add(product);
                await _context.SaveChangesAsync();

                // Crear el inventario
                var inventory = new Inventory
                {
                    ProductId = product.ProductId,
                    EntryDate = productCreateDto.Inventory.EntryDate,
                    Price = productCreateDto.Inventory.Price,
                    Quantity = productCreateDto.Inventory.Quantity,
                    BranchId = productCreateDto.Inventory.BranchId,
                    AcquisitionFolio = productCreateDto.Inventory.AcquisitionFolio,
                    Invoice = productCreateDto.Inventory.Invoice,
                    Supplier = productCreateDto.Inventory.Supplier
                };

                _context.Inventories.Add(inventory);
                await _context.SaveChangesAsync();

                // Retornar el producto con el inventario creado
                var createdProductDto = new ProductDTO
                {
                    ProductId = product.ProductId,
                    IsJewel = (bool)product.IsJewel,
                    SubFamilyId = (int)product.SubFamilyId,
                    CreationDate = (DateTime)product.CreationDate,
                    Name = product.Name,
                    Description = product.Description,
                    Status = product.Status,
                    IsActive = (bool)product.IsActive,
                    ImageUrl = product.ImageUrl,
                    Price = (decimal)inventory.Price  // Asignar el precio del inventario al DTO del producto
                };

                return CreatedAtAction(nameof(GetProduct), new { id = product.ProductId }, createdProductDto);
            }

            // DELETE: api/Product/5
            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteProduct(int id)
            {
                var product = await _context.Products.FindAsync(id);
                if (product == null)
                {
                    return NotFound();
                }

                _context.Products.Remove(product);
                await _context.SaveChangesAsync();

                return NoContent();
            }

            private bool ProductExists(int id)
            {
                return _context.Products.Any(e => e.ProductId == id);
            }
        }
    }
