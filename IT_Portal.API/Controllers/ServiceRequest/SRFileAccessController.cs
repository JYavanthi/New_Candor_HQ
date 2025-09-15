using IT_Portal.Application.Contracts.Persistence.SR;
using IT_Portal.Application.Features;
using IT_Portal.Application.Features.SR;
using Microsoft.AspNetCore.Mvc;

namespace IT_Portal.API.Controllers.ServiceRequest
{
    [Route("api/[controller]")]
    [ApiController]
    public class SRFileAccessController : ControllerBase
    {
        private readonly ISRFileAccess _sRFile;

        public SRFileAccessController(ISRFileAccess sRFile)
        {
            this._sRFile = sRFile;
        }
        [HttpPost("PostFileAccess")]
        public async Task<CommonRsult> PostSRFileAccess(SRFileAccess fileAccess)
        {
            return await _sRFile.PostSRFileAccess(fileAccess);
        }
        [HttpGet("GetFileAccess")]
        public async Task<CommonRsult> GetSRFileAccess()
        {
            return await _sRFile.GetSRFileAccess();
        }
        [HttpGet("GetFileAccessValue")]
        public async Task<CommonRsult> GetSRFileAccessValue(int srid)
        {
            return await _sRFile.GetSRFileAccessValue(srid);
        }
    }
}
