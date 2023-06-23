
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Example07.Models;
namespace Example07.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly Example07Context _context;
        public PostsController(Example07Context context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Post>>> GetPosts()
        {
            if (_context.Posts == null)
            {
                return NotFound();
            }
            return await _context.Posts.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Post>> GetPost(long id)
        {
            if (_context.Posts == null)
            {
                return NotFound();
            }
            var Post = await _context.Posts.FindAsync(id);
            if (Post == null)
            {
                return NotFound();
            }
            return Post;
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPost(long id, Post post)
        {
            if (id != post.Id)
            {
                return BadRequest();
            }
            _context.Entry(post).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PostExists(id))
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
        public async Task<ActionResult<Post>> PostPost(Post post)
        {
            if (_context.Posts == null)
            {
                return Problem("Entity set 'Example07Context.Posts' is null.");
            }
            _context.Posts.Add(post);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetPost", new { id = post.Id }, post);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost(long id)
        {
            if (_context.Posts == null)
            {
                return NotFound();
            }
            var Post = await _context.Posts.FindAsync(id);
            if (Post == null)
            {
                return NotFound();
            }
            _context.Posts.Remove(Post);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        private bool PostExists(long id)
        {
            return (_context.Posts?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
