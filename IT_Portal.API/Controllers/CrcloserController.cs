using IT_Portal.Application.Contracts.Persistence;
using IT_Portal.Application.Features;
using IT_Portal.Persistence.DatabaseContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IT_Portal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrcloserController : ControllerBase
    {
        private readonly Icrcloser _crclosercontext;
        private readonly MicroLabsDevContext _context;

        public CrcloserController(Icrcloser crclosercontext, MicroLabsDevContext context)
        {
            this._crclosercontext = crclosercontext;
            this._context = context;
        }

        [HttpPost("Closer")]
        public async Task<IActionResult> Crcloser(Crcloser obj)
        {
            var spObj = await _crclosercontext.CRcloser(obj);
            return Ok(spObj);
        }
        [HttpGet("GetCloser")]
        public async Task<IActionResult> GetRequest()
        {
            var data = await _context.VwCrclosures.ToListAsync();
            return Ok(data);
        }
    }
}
