using Example07.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace Example07.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly Example07Context _context;
        public CategoriesController(Example07Context context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategory()
        {
            if (_context.Categories == null)
            {
                return NotFound();
            }
            return await _context.Categories.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategories(long id)
        {
            if (_context.Categories == null)
            {
                return NotFound();
            }
            var product = await _context.Categories.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return product;
        }
        [HttpPost]
        public async Task<ActionResult<Category>> AddCategory(Category cate)
        {
            if (_context.Categories == null)
            {
                return Problem("Entity set 'Example07Context.Categories' is null.");
            }
            _context.Categories.Add(cate);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetCategory", new { id = cate.Id }, cate);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(long id, Category cate)
        {
            if (id != cate.Id)
            {
                return BadRequest();
            }
            _context.Entry(cate).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(id))
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
        public async Task<IActionResult> DeleteCategory(long id)
        {
            if (_context.Categories == null)
            {
                return NotFound();
            }
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        private bool CategoryExists(long id)
        {
            return (_context.Categories?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}