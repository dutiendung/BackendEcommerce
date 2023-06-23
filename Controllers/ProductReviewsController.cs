
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Example07.Models;
namespace Example07.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductReviewsController : ControllerBase
    {
        private readonly Example07Context _context;
        public ProductReviewsController(Example07Context context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductReview>>> GetProductReviews()
        {
            if (_context.ProductReviews == null)
            {
                return NotFound();
            }
            return await _context.ProductReviews.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductReview>> GetProduct(long id)
        {
            if (_context.ProductReviews == null)
            {
                return NotFound();
            }
            var ProductReview = await _context.ProductReviews.FindAsync(id);
            if (ProductReview == null)
            {
                return NotFound();
            }
            return ProductReview;
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(long id, ProductReview productReview)
        {
            if (id != productReview.Id)
            {
                return BadRequest();
            }
            _context.Entry(productReview).State = EntityState.Modified;
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
        [HttpPost]
        public async Task<ActionResult<ProductReview>> PostProduct(ProductReview productReview)
        {
            if (_context.ProductReviews == null)
            {
                return Problem("Entity set 'Example07Context.ProductReviews' is null.");
            }
            _context.ProductReviews.Add(productReview);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetProduct", new { id = productReview.Id }, productReview);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductReview(long id)
        {
            if (_context.ProductReviews == null)
            {
                return NotFound();
            }
            var product = await _context.ProductReviews.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            _context.ProductReviews.Remove(product);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        private bool ProductExists(long id)
        {
            return (_context.ProductReviews?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
