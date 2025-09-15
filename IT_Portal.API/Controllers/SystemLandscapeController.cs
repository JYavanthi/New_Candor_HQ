using IT_Portal.Application.Contracts.Persistence;
using IT_Portal.Application.Features.SystemLandscapeData;
using IT_Portal.Persistence.DatabaseContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IT_Portal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SystemLandscapeController : ControllerBase
    {
        private readonly ISystemLandscape _systencontext;
        private readonly MicroLabsDevContext _context;

        public SystemLandscapeController(ISystemLandscape systencontext, MicroLabsDevContext context)
        {
            this._systencontext = systencontext;
            this._context = context;
        }

        [HttpPost("Getsystems")]
        public async Task<IActionResult> Getsystems([FromBody] CommonCR getObj)
        {
            var data = await _systencontext.GetLandscapes(getObj);
            return Ok(data);
        }

        [HttpGet("Allsystems")]
        public async Task<IActionResult> GetSystem()
        {
            var data = await _context.SysLandscapes.ToListAsync();
            return Ok(data);
        }

        [HttpGet("ViewSystemLans")]
        public async Task<IActionResult> ViewSystemLans()
        {
            var data = await _context.VwSystemlandscapes.ToListAsync();
            return Ok(data);
        }
    }
}