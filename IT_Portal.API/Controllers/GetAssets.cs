using IT_Portal.Persistence.DatabaseContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IT_Portal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetAssets : ControllerBase
    {
        private readonly MicroLabsDevContext _context;

        public GetAssets(MicroLabsDevContext context)
        {
            this._context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetAsset()
        {
            var data = await _context.VwItassetsDetails.ToListAsync();
            return Ok(data);
        }
    }
}
