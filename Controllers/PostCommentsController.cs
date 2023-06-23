
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Example07.Models;
namespace Example07.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostCommentsController : ControllerBase
    {
        private readonly Example07Context _context;
        public PostCommentsController(Example07Context context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PostComment>>> GetPostComments()
        {
            if (_context.PostComments == null)
            {
                return NotFound();
            }
            return await _context.PostComments.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<PostComment>> GetPostComment(long id)
        {
            if (_context.PostComments == null)
            {
                return NotFound();
            }
            var PostComment = await _context.PostComments.FindAsync(id);
            if (PostComment == null)
            {
                return NotFound();
            }
            return PostComment;
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPostComment(long id, PostComment postComment)
        {
            if (id != postComment.Id)
            {
                return BadRequest();
            }
            _context.Entry(postComment).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PostCommentExists(id))
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
        public async Task<ActionResult<PostComment>> PostPostComment(PostComment postComment)
        {
            if (_context.PostComments == null)
            {
                return Problem("Entity set 'Example07Context.PostComments' is null.");
            }
            _context.PostComments.Add(postComment);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetPostComment", new { id = postComment.Id }, postComment);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePostComment(long id)
        {
            if (_context.PostComments == null)
            {
                return NotFound();
            }
            var PostComment = await _context.PostComments.FindAsync(id);
            if (PostComment == null)
            {
                return NotFound();
            }
            _context.PostComments.Remove(PostComment);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        private bool PostCommentExists(long id)
        {
            return (_context.PostComments?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
