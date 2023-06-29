
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Example07.Models;
namespace Example07.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DealsController : ControllerBase
    {
        private readonly Example07Context _context;
        public DealsController(Example07Context context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<Deal>> GetHotDeal()
        {
            if (_context.Deals == null)
            {
                return NotFound();
            }
            var now = DateTime.Now.Date;
            return _context.Deals.Where(x => x.Starts <= now && x.Ends >= now).First();
        }

    }
}
