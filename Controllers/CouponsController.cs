
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Example07.Models;
namespace Example07.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponsController : ControllerBase
    {
        private readonly Example07Context _context;
        public CouponsController(Example07Context context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Coupon>>> GetCoupons()
        {
            if (_context.Coupons == null)
            {
                return NotFound();
            }
            return await _context.Coupons.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Coupon>> GetCoupon(long id)
        {
            if (_context.Coupons == null)
            {
                return NotFound();
            }
            var Coupon = await _context.Coupons.FindAsync(id);
            if (Coupon == null)
            {
                return NotFound();
            }
            return Coupon;
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCoupon(long id, Coupon coupon)
        {
            if (id != coupon.Id)
            {
                return BadRequest();
            }
            _context.Entry(coupon).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CouponExists(id))
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
        public async Task<ActionResult<Coupon>> PostCoupon(Coupon coupon)
        {
            if (_context.Coupons == null)
            {
                return Problem("Entity set 'Example07Context.Coupons' is null.");
            }
            _context.Coupons.Add(coupon);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetCoupon", new { id = coupon.Id }, coupon);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCoupon(long id)
        {
            if (_context.Coupons == null)
            {
                return NotFound();
            }
            var Coupon = await _context.Coupons.FindAsync(id);
            if (Coupon == null)
            {
                return NotFound();
            }
            _context.Coupons.Remove(Coupon);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        private bool CouponExists(long id)
        {
            return (_context.Coupons?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
