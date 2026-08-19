using IT_Portal.Application.Contracts.Persistence;
using IT_Portal.Application.Features;
using IT_Portal.Persistence.DatabaseContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IT_Portal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NatureofChangeController : ControllerBase
    {
        private readonly INatureofChange _nccontext;
        private readonly MicroLabsDevContext _context;

        public NatureofChangeController(INatureofChange nccontext, MicroLabsDevContext context)
        {
            this._nccontext = nccontext;
            this._context = context;
        }

        [HttpPost("postnatureofchange")]
        public async Task<IActionResult> PostCategory(SPNatureofchange obj)
        {
            var spObj = await _nccontext.PostNatureofchange(obj);
            return Ok(spObj);
        }

        [HttpGet]
        public async Task<IActionResult> Getnatureofchange()
        {
            var data = await _context.NatureofChanges.ToListAsync();
            return Ok(data);
        }

        [HttpGet("ViewNatureofchange")]
        public async Task<IActionResult> ViewNatureofchange()
        {
            var data = await _context.VwNatureofChanges.ToListAsync();
            return Ok(data);
        }
    }
}
