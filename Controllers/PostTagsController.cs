
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Example07.Models;
namespace Example07.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostTagsController : ControllerBase
    {
        private readonly Example07Context _context;
        public PostTagsController(Example07Context context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PostTag>>> GetPostTags()
        {
            if (_context.PostTags == null)
            {
                return NotFound();
            }
            return await _context.PostTags.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<PostTag>> GetPostTag(long id)
        {
            if (_context.PostTags == null)
            {
                return NotFound();
            }
            var PostTag = await _context.PostTags.FindAsync(id);
            if (PostTag == null)
            {
                return NotFound();
            }
            return PostTag;
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPostTag(long id, PostTag postTag)
        {
            if (id != postTag.Id)
            {
                return BadRequest();
            }
            _context.Entry(postTag).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PostTagExists(id))
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
        public async Task<ActionResult<PostTag>> PostPostTag(PostTag postTag)
        {
            if (_context.PostTags == null)
            {
                return Problem("Entity set 'Example07Context.PostTags' is null.");
            }
            _context.PostTags.Add(postTag);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetPostTag", new { id = postTag.Id }, postTag);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePostTag(long id)
        {
            if (_context.PostTags == null)
            {
                return NotFound();
            }
            var PostTag = await _context.PostTags.FindAsync(id);
            if (PostTag == null)
            {
                return NotFound();
            }
            _context.PostTags.Remove(PostTag);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        private bool PostTagExists(long id)
        {
            return (_context.PostTags?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
