using IT_Portal.Application.Contracts.Persistence.SR;
using IT_Portal.Application.Features;
using IT_Portal.Application.Features.SR;
using IT_Portal.Persistence.DatabaseContext;
using Microsoft.AspNetCore.Mvc;

namespace IT_Portal.API.Controllers.ServiceRequest
{
    [Route("api/[controller]")]
    [ApiController]
    public class SRAntivirusController : ControllerBase
    {
        private readonly MicroLabsDevContext _context;
        private readonly IAntivirus _antivirus;

        public SRAntivirusController(MicroLabsDevContext context, IAntivirus antivirus)
        {
            this._context = context;
            this._antivirus = antivirus;
        }
        [HttpGet("GetAntivirus")]
        public async Task<CommonRsult> GetAntivirus(int srid)
        {
            var data = await _antivirus.GetAntivirus(srid);
            return data;
        }

        [HttpPost("PostAntivirus")]
        public async Task<CommonRsult> PostAntivirus(Antivirus antivirus)
        {
            var data = await _antivirus.PostAntivirus(antivirus);
            return data;
        }

    }
}
