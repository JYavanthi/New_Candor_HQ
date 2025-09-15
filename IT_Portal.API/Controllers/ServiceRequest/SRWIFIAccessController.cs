using IT_Portal.Application.Contracts.Persistence.SR;
using IT_Portal.Application.Features;
using IT_Portal.Application.Features.SR;
using Microsoft.AspNetCore.Mvc;

namespace IT_Portal.API.Controllers.ServiceRequest
{
    [Route("api/[controller]")]
    [ApiController]
    public class SRWIFIAccessController : ControllerBase
    {
        private readonly ISRWIFIAccess _sRWIFI;

        public SRWIFIAccessController(ISRWIFIAccess sRWIFI)
        {
            this._sRWIFI = sRWIFI;
        }
        [HttpPost("PostWIFIAccess")]
        public async Task<CommonRsult> PostWIFIAccess(SRWIFIAccess sRWIFI)
        {
            return await _sRWIFI.PostWIFIAccess(sRWIFI);
        }
        [HttpGet("GetWIFIAccess")]
        public async Task<CommonRsult> GetWIFIAccess(int srid)
        {
            return await _sRWIFI.GetWIFIAccess(srid);
        }
    }
}
