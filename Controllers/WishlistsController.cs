
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Example07.Models;
namespace Example07.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WishlistsController : ControllerBase
    {
        private readonly Example07Context _context;
        public WishlistsController(Example07Context context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Wishlist>>> GetWishlists()
        {
            if (_context.Wishlists == null)
            {
                return NotFound();
            }
            return await _context.Wishlists.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Wishlist>> GetWishlist(long id)
        {
            if (_context.Wishlists == null)
            {
                return NotFound();
            }
            var Wishlist = await _context.Wishlists.FindAsync(id);
            if (Wishlist == null)
            {
                return NotFound();
            }
            return Wishlist;
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWishlist(long id, Wishlist wishlist)
        {
            if (id != wishlist.Id)
            {
                return BadRequest();
            }
            _context.Entry(wishlist).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WishlistExists(id))
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
        public async Task<ActionResult<Wishlist>> PostWishlist(Wishlist wishlist)
        {
            if (_context.Wishlists == null)
            {
                return Problem("Entity set 'Example07Context.Wishlists' is null.");
            }
            _context.Wishlists.Add(wishlist);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetWishlist", new { id = wishlist.Id }, wishlist);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWishlist(long id)
        {
            if (_context.Wishlists == null)
            {
                return NotFound();
            }
            var Wishlist = await _context.Wishlists.FindAsync(id);
            if (Wishlist == null)
            {
                return NotFound();
            }
            _context.Wishlists.Remove(Wishlist);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        private bool WishlistExists(long id)
        {
            return (_context.Wishlists?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
