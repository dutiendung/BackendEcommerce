
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Example07.Models;
namespace Example07.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartsController : ControllerBase
    {
        private readonly Example07Context _context;
        public CartsController(Example07Context context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cart>>> GetCarts()
        {
            if (_context.Carts == null)
            {
                return NotFound();
            }
            return await _context.Carts.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Cart>> GetCart(long id)
        {
            if (_context.Carts == null)
            {
                return NotFound();
            }
            var Cart = await _context.Carts.FindAsync(id);
            if (Cart == null)
            {
                return NotFound();
            }
            return Cart;
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCart(long id, Cart cart)
        {
            if (id != cart.Id)
            {
                return BadRequest();
            }
            _context.Entry(cart).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CartExists(id))
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
        public async Task<ActionResult<Cart>> PostCart(Cart cart)
        {
            if (_context.Carts == null)
            {
                return Problem("Entity set 'Example07Context.Carts' is null.");
            }
            _context.Carts.Add(cart);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetCart", new { id = cart.Id }, cart);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCart(long id)
        {
            if (_context.Carts == null)
            {
                return NotFound();
            }
            var Cart = await _context.Carts.FindAsync(id);
            if (Cart == null)
            {
                return NotFound();
            }
            _context.Carts.Remove(Cart);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        private bool CartExists(long id)
        {
            return (_context.Carts?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
