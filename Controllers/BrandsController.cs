using Example07.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace Example07.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly Example07Context _context;
        public BrandsController(Example07Context context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Brand>>> GetBrands()
        {
            if (_context.Brands == null)
            {
                return NotFound();
            }
            return await _context.Brands.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Brand>> GetBrand(long id)
        {
            if (_context.Brands == null)
            {
                return NotFound();
            }
            var brand = await _context.Brands.FindAsync(id);
            if (brand == null)
            {
                return NotFound();
            }
            return brand;
        }
        [HttpPost]
        public async Task<ActionResult<Brand>> AddBrand(Brand brand)
        {
            if (_context.Brands == null)
            {
                return Problem("Entity set 'Example07Context.Brands' is null.");
            }
            _context.Brands.Add(brand);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetBrand", new { id = brand.Id }, brand);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBrand(long id, Brand brand)
        {
            if (id != brand.Id)
            {
                return BadRequest();
            }
            _context.Entry(brand).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BrandExists(id))
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
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBrand(long id)
        {
            if (_context.Brands == null)
            {
                return NotFound();
            }
            var brand = await _context.Brands.FindAsync(id);
            if (brand == null)
            {
                return NotFound();
            }
            _context.Brands.Remove(brand);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        private bool BrandExists(long id)
        {
            return (_context.Brands?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}