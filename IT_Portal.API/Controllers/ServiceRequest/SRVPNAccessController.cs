using IT_Portal.Application.Contracts.Persistence.SR;
using IT_Portal.Application.Features;
using IT_Portal.Application.Features.SR;
using Microsoft.AspNetCore.Mvc;

namespace IT_Portal.API.Controllers.ServiceRequest
{
    [Route("api/[controller]")]
    [ApiController]
    public class SRVPNAccessController : ControllerBase
    {
        private readonly ISRVPNAccess _access;

        public SRVPNAccessController(ISRVPNAccess access)
        {
            this._access = access;
        }
        [HttpPost("PostVPNAccess")]
        public async Task<CommonRsult> PostVPNAccess(SRVPNAccess sRVPN)
        {
            return await _access.PostVPNAccess(sRVPN);
        }
        [HttpGet("GetVPNAccess")]
        public async Task<CommonRsult> GetVPNAccess()
        {
            return await _access.GetVPNAccess();
        }
        [HttpGet("GetVPNAccessValue")]
        public async Task<CommonRsult> GetVPNAccessValue(int srid)
        {
            return await _access.GetVPNAccessValue(srid);
        }
    }
}
