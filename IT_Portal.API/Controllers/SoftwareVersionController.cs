using IT_Portal.Application.Contracts;
using IT_Portal.Application.Features;
using IT_Portal.Persistence.DatabaseContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IT_Portal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SoftwareVersionController : ControllerBase
    {
        private readonly ISoftwareVersion _software;
        private readonly MicroLabsDevContext _context;

        public SoftwareVersionController(ISoftwareVersion software, MicroLabsDevContext context)
        {
            this._software = software;
            this._context = context;
        }
        [HttpPost("PostSoftwareVersion")]
        public async Task<CommonRsult> PostSoftwareVersion(SoftwareVerison software)
        {
            var spObj = await _software.PostSoftwareVersion(software);
            return spObj;
        }
        [HttpGet("GetSoftwareversionValue")]
        public async Task<IActionResult> GetSoftwareversion()
        {
            var data = await _context.VwSoftwareVersions.ToListAsync();
            return Ok(data);
        }
    }
}
