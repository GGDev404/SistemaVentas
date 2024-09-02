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
    public class SubFamilyController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SubFamilyController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/SubFamily
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubFamilyDTO>>> GetSubFamilies()
        {
            var subFamilies = await _context.SubFamilies
                .Include(s => s.Family)
                .Select(s => new SubFamilyDTO
                {
                    SubFamilyId = s.SubFamilyId,
                    FamilyId = (int)s.FamilyId,
                    Name = s.Name,
                    Description = s.Description,
                    IsActive = (bool)s.IsActive,
                    Status = s.Status
                })
                .ToListAsync();

            return Ok(subFamilies);
        }

        // GET: api/SubFamily/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SubFamilyDTO>> GetSubFamily(int id)
        {
            var subFamily = await _context.SubFamilies
                .Where(s => s.SubFamilyId == id)
                .Select(s => new SubFamilyDTO
                {
                    SubFamilyId = s.SubFamilyId,
                    FamilyId = (int)s.FamilyId,
                    Name = s.Name,
                    Description = s.Description,
                    IsActive = (bool)s.IsActive,
                    Status = s.Status
                })
                .FirstOrDefaultAsync();

            if (subFamily == null)
            {
                return NotFound();
            }

            return Ok(subFamily);
        }

        // PUT: api/SubFamily/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubFamily(int id, SubFamilyDTO subFamilyDto)
        {
            if (id != subFamilyDto.SubFamilyId)
            {
                return BadRequest();
            }

            var subFamily = await _context.SubFamilies.FindAsync(id);
            if (subFamily == null)
            {
                return NotFound();
            }

            subFamily.FamilyId = subFamilyDto.FamilyId;
            subFamily.Name = subFamilyDto.Name;
            subFamily.Description = subFamilyDto.Description;
            subFamily.IsActive = subFamilyDto.IsActive;
            subFamily.Status = subFamilyDto.Status;

            _context.Entry(subFamily).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubFamilyExists(id))
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

        // POST: api/SubFamily
        [HttpPost]
        public async Task<ActionResult<SubFamilyDTO>> PostSubFamily(SubFamilyDTO subFamilyDto)
        {
            var subFamily = new SubFamily
            {
                FamilyId = subFamilyDto.FamilyId,
                Name = subFamilyDto.Name,
                Description = subFamilyDto.Description,
                IsActive = subFamilyDto.IsActive,
                Status = subFamilyDto.Status
            };

            _context.SubFamilies.Add(subFamily);
            await _context.SaveChangesAsync();

            var createdSubFamilyDto = new SubFamilyDTO
            {
                SubFamilyId = subFamily.SubFamilyId,
                FamilyId = (int)subFamily.FamilyId,
                Name = subFamily.Name,
                Description = subFamily.Description,
                IsActive = (bool)subFamily.IsActive,
                Status = subFamily.Status
            };

            return CreatedAtAction(nameof(GetSubFamily), new { id = subFamily.SubFamilyId }, createdSubFamilyDto);
        }

        // DELETE: api/SubFamily/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubFamily(int id)
        {
            var subFamily = await _context.SubFamilies.FindAsync(id);
            if (subFamily == null)
            {
                return NotFound();
            }

            _context.SubFamilies.Remove(subFamily);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SubFamilyExists(int id)
        {
            return _context.SubFamilies.Any(e => e.SubFamilyId == id);
        }
    }
}
