
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Example07.Models;
namespace Example07.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        private readonly Example07Context _context;
        public NotificationsController(Example07Context context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Notification>>> GetNotifications()
        {
            if (_context.Notifications == null)
            {
                return NotFound();
            }
            return await _context.Notifications.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Notification>> GetNotification(long id)
        {
            if (_context.Notifications == null)
            {
                return NotFound();
            }
            var Notification = await _context.Notifications.FindAsync(id);
            if (Notification == null)
            {
                return NotFound();
            }
            return Notification;
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNotification(long id, Notification notification)
        {
            if (id != notification.Id)
            {
                return BadRequest();
            }
            _context.Entry(notification).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NotificationExists(id))
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
        public async Task<ActionResult<Notification>> PostNotification(Notification notification)
        {
            if (_context.Notifications == null)
            {
                return Problem("Entity set 'Example07Context.Notifications' is null.");
            }
            _context.Notifications.Add(notification);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetNotification", new { id = notification.Id }, notification);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNotification(long id)
        {
            if (_context.Notifications == null)
            {
                return NotFound();
            }
            var Notification = await _context.Notifications.FindAsync(id);
            if (Notification == null)
            {
                return NotFound();
            }
            _context.Notifications.Remove(Notification);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        private bool NotificationExists(long id)
        {
            return (_context.Notifications?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
