
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Example07.Models;
namespace Example07.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BannersController : ControllerBase
    {
        private readonly Example07Context _context;
        public BannersController(Example07Context context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Banner>>> GetBanners()
        {
            if (_context.Banners == null)
            {
                return NotFound();
            }
            return await _context.Banners.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Banner>> GetBannder(long id)
        {
            if (_context.Banners == null)
            {
                return NotFound();
            }
            var banner = await _context.Banners.FindAsync(id);
            if (banner == null)
            {
                return NotFound();
            }
            return banner;
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBanner(long id, Banner banner)
        {
            if (id != banner.Id)
            {
                return BadRequest();
            }
            _context.Entry(banner).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BannerExists(id))
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
        public async Task<ActionResult<Banner>> PostProduct(Banner banner)
        {
            if (_context.Banners == null)
            {
                return Problem("Entity set 'Example07Context.Banners' is null.");
            }
            _context.Banners.Add(banner);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBanner(long id)
        {
            if (_context.Banners == null)
            {
                return NotFound();
            }
            var banner = await _context.Banners.FindAsync(id);
            if (banner == null)
            {
                return NotFound();
            }
            _context.Banners.Remove(banner);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        private bool BannerExists(long id)
        {
            return (_context.Banners?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
