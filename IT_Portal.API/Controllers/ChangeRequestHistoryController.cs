using IT_Portal.Persistence.DatabaseContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IT_Portal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChangeRequestHistoryController : ControllerBase
    {
        private readonly MicroLabsDevContext _context;

        public ChangeRequestHistoryController(MicroLabsDevContext context)
        {
            this._context = context;
        }

        [HttpGet("GetCrhistory")]
        public async Task<IActionResult> GetCrHistory()
        {
            var data = await _context.ChangeRequestHistories.ToListAsync();
            return Ok(data);
        }
    }
}
