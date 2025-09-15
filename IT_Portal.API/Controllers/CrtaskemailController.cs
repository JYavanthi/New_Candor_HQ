using IT_Portal.Persistence.DatabaseContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IT_Portal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrtaskemailController : ControllerBase
    {
        private readonly MicroLabsDevContext _context;

        public CrtaskemailController(MicroLabsDevContext context)
        {
            this._context = context;
        }

        [HttpGet("GetCrTaskEmail")]
        public async Task<IActionResult> GetRequest()
        {
            var data = await _context.VwCrtaskEmails.ToListAsync();
            return Ok(data);
        }
    }
}
