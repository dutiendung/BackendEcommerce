
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Example07.Models;
namespace Example07.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShippingsController : ControllerBase
    {
        private readonly Example07Context _context;
        public ShippingsController(Example07Context context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Shipping>>> GetShippings()
        {
            if (_context.Shippings == null)
            {
                return NotFound();
            }
            return await _context.Shippings.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Shipping>> GetShipping(long id)
        {
            if (_context.Shippings == null)
            {
                return NotFound();
            }
            var Shipping = await _context.Shippings.FindAsync(id);
            if (Shipping == null)
            {
                return NotFound();
            }
            return Shipping;
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShipping(long id, Shipping shipping)
        {
            if (id != shipping.Id)
            {
                return BadRequest();
            }
            _context.Entry(shipping).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShippingExists(id))
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
        [HttpPost]
        public async Task<ActionResult<Shipping>> PostShipping(Shipping shipping)
        {
            if (_context.Shippings == null)
            {
                return Problem("Entity set 'Example07Context.Shippings' is null.");
            }
            _context.Shippings.Add(shipping);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetShipping", new { id = shipping.Id }, shipping);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShipping(long id)
        {
            if (_context.Shippings == null)
            {
                return NotFound();
            }
            var Shipping = await _context.Shippings.FindAsync(id);
            if (Shipping == null)
            {
                return NotFound();
            }
            _context.Shippings.Remove(Shipping);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        private bool ShippingExists(long id)
        {
            return (_context.Shippings?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
