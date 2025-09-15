using IT_Portal.Application.Contracts.Persistence.SR;
using IT_Portal.Application.Features;
using IT_Portal.Application.Features.SR;
using Microsoft.AspNetCore.Mvc;

namespace IT_Portal.API.Controllers.ServiceRequest
{
    [Route("api/[controller]")]
    [ApiController]
    public class SRRestorationController : ControllerBase
    {
        private readonly ISRRestoration _sR;

        public SRRestorationController(ISRRestoration sR)
        {
            this._sR = sR;
        }
        [HttpPost("PostRestoration")]
        public async Task<CommonRsult> PostSRRestoration(SRRestoration restoration)
        {
            return await _sR.PostSRRestoration(restoration);
        }
        [HttpGet("GetSRRestorationbyID")]
        public async Task<CommonRsult> GetSRRestoration(int srid)
        {
            return await _sR.GetSRRestoration(srid);
        }
    }
}
