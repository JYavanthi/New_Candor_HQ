using IT_Portal.Application.Contracts.Persistence.SR;
using IT_Portal.Application.Features;
using IT_Portal.Application.Features.SR;
using Microsoft.AspNetCore.Mvc;

namespace IT_Portal.API.Controllers.ServiceRequest
{
    [Route("api/[controller]")]
    [ApiController]
    public class SRURLAccessController : ControllerBase
    {
        private readonly ISRURLAccess _access;

        public SRURLAccessController(ISRURLAccess access)
        {
            this._access = access;
        }
        [HttpPost("PostURLAccess")]
        public async Task<CommonRsult> PostURLAccess(SRURLAccess sRURL)
        {
            return await _access.PostURLAccess(sRURL);
        }
        [HttpGet("GetURLAccess")]
        public async Task<CommonRsult> GetURLAccess()
        {
            return await _access.GetURLAccess();
        }
        [HttpGet("GetURLAccessValue")]
        public async Task<CommonRsult> GetURLAccessValue(int srid)
        {
            return await _access.GetURLAccessValue(srid);
        }
    }
}
