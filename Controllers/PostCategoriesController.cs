
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Example07.Models;
namespace Example07.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostCategoriesController : ControllerBase
    {
        private readonly Example07Context _context;
        public PostCategoriesController(Example07Context context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PostCategory>>> GetPostCategories()
        {
            if (_context.PostCategories == null)
            {
                return NotFound();
            }
            return await _context.PostCategories.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<PostCategory>> GetPostCategory(long id)
        {
            if (_context.PostCategories == null)
            {
                return NotFound();
            }
            var PostCategory = await _context.PostCategories.FindAsync(id);
            if (PostCategory == null)
            {
                return NotFound();
            }
            return PostCategory;
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPostCategory(long id, PostCategory postCategory)
        {
            if (id != postCategory.Id)
            {
                return BadRequest();
            }
            _context.Entry(postCategory).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PostCategoryExists(id))
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
        public async Task<ActionResult<PostCategory>> PostPostCategory(PostCategory postCategory)
        {
            if (_context.PostCategories == null)
            {
                return Problem("Entity set 'Example07Context.PostCategories' is null.");
            }
            _context.PostCategories.Add(postCategory);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetPostCategory", new { id = postCategory.Id }, postCategory);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePostCategory(long id)
        {
            if (_context.PostCategories == null)
            {
                return NotFound();
            }
            var PostCategory = await _context.PostCategories.FindAsync(id);
            if (PostCategory == null)
            {
                return NotFound();
            }
            _context.PostCategories.Remove(PostCategory);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        private bool PostCategoryExists(long id)
        {
            return (_context.PostCategories?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
