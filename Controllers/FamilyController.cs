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
    public class FamilyController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public FamilyController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Family
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FamilyDTO>>> GetFamilies()
        {
            var families = await _context.Families
                .Select(f => new FamilyDTO
                {
                    FamilyId = f.FamilyId,
                    IsJewel = (bool)f.IsJewel,
                    CreationDate = (DateTime)f.CreationDate,
                    Name = f.Name,
                    Description = f.Description,
                    Status = f.Status,
                    IsActive = (bool)f.IsActive
                })
                .ToListAsync();

            return Ok(families);
        }

        // GET: api/Family/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FamilyDTO>> GetFamily(int id)
        {
            var family = await _context.Families
                .Where(f => f.FamilyId == id)
                .Select(f => new FamilyDTO
                {
                    FamilyId = f.FamilyId,
                    IsJewel = (bool)f.IsJewel,
                    CreationDate = (DateTime)f.CreationDate,
                    Name = f.Name,
                    Description = f.Description,
                    Status = f.Status,
                    IsActive = (bool)f.IsActive
                })
                .FirstOrDefaultAsync();

            if (family == null)
            {
                return NotFound();
            }

            return Ok(family);
        }

        // PUT: api/Family/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFamily(int id, FamilyDTO familyDto)
        {
            if (id != familyDto.FamilyId)
            {
                return BadRequest();
            }

            var family = await _context.Families.FindAsync(id);
            if (family == null)
            {
                return NotFound();
            }

            family.IsJewel = familyDto.IsJewel;
            family.CreationDate = familyDto.CreationDate;
            family.Name = familyDto.Name;
            family.Description = familyDto.Description;
            family.Status = familyDto.Status;
            family.IsActive = familyDto.IsActive;

            _context.Entry(family).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FamilyExists(id))
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

        // POST: api/Family
        [HttpPost]
        public async Task<ActionResult<FamilyDTO>> PostFamily(FamilyDTO familyDto)
        {
            var family = new Family
            {
                IsJewel = familyDto.IsJewel,
                CreationDate = familyDto.CreationDate,
                Name = familyDto.Name,
                Description = familyDto.Description,
                Status = familyDto.Status,
                IsActive = familyDto.IsActive
            };

            _context.Families.Add(family);
            await _context.SaveChangesAsync();

            var createdFamilyDto = new FamilyDTO
            {
                FamilyId = family.FamilyId,
                IsJewel = (bool)family.IsJewel,
                CreationDate = (DateTime)family.CreationDate,
                Name = family.Name,
                Description = family.Description,
                Status = family.Status,
                IsActive = (bool)family.IsActive
            };

            return CreatedAtAction(nameof(GetFamily), new { id = family.FamilyId }, createdFamilyDto);
        }

        // DELETE: api/Family/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFamily(int id)
        {
            var family = await _context.Families.FindAsync(id);
            if (family == null)
            {
                return NotFound();
            }

            _context.Families.Remove(family);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FamilyExists(int id)
        {
            return _context.Families.Any(e => e.FamilyId == id);
        }
    }
}
