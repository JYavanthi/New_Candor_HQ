using IT_Portal.Application.Contracts.Persistence;
using IT_Portal.Application.Features;
using IT_Portal.Persistence.DatabaseContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IT_Portal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CRreleaseController : ControllerBase
    {
        private readonly ICrrelease _releasercontext;
        private readonly MicroLabsDevContext _context;

        public CRreleaseController(ICrrelease releasercontext, MicroLabsDevContext context)
        {
            this._releasercontext = releasercontext;
            this._context = context;
        }

        [HttpPost("Releaser")]
        public async Task<IActionResult> Crexecute(SPCrrelease obj)
        {
            var spObj = await _releasercontext.CRrelease(obj);
            return Ok(spObj);
        }
        [HttpGet("GetRelease")]
        public async Task<IActionResult> GetRequest()
        {
            var data = await _context.Crreleases.ToListAsync();
            return Ok(data);
        }
    }
}
