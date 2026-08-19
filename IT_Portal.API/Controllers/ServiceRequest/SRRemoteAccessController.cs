using IT_Portal.Application.Contracts.Persistence.SR;
using IT_Portal.Application.Features;
using Microsoft.AspNetCore.Mvc;

namespace IT_Portal.API.Controllers.ServiceRequest
{
    [Route("api/[controller]")]
    [ApiController]
    public class SRRemoteAccessController : ControllerBase
    {
        private readonly ISRRemoteAccess _sRRemote;

        public SRRemoteAccessController(ISRRemoteAccess sRRemote)
        {
            this._sRRemote = sRRemote;
        }
        [HttpPost("PostSRRemoteAccess")]
        public async Task<CommonRsult> PostSRRemoteAccess(SRRemoteAccess access)
        {
            return await _sRRemote.PostSRRemoteAccess(access);
        }
        [HttpGet("GetSRRemoteAccess")]
        public async Task<CommonRsult> GetSRRemoteAccess()
        {
            return await _sRRemote.GetSRRemoteAccess();
        }
        [HttpGet("GetSRRemoteAccessById")]
        public async Task<CommonRsult> GetSRRemoteAccessById(int srid)
        {

            return await _sRRemote.GetSRRemoteAccessById(srid);
        }
    }
}
