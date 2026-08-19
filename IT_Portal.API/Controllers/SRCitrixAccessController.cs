using IT_Portal.Application.Contracts.Persistence.SR;
using IT_Portal.Application.Features;
using IT_Portal.Application.Features.SR;
using Microsoft.AspNetCore.Mvc;

namespace IT_Portal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SRCitrixAccessController : ControllerBase
    {
        private readonly ISRCitrixAccess _sRCitrix;

        public SRCitrixAccessController(ISRCitrixAccess sRCitrix)
        {
            this._sRCitrix = sRCitrix;
        }
        [HttpPost("PostCitrixAccess")]
        public async Task<CommonRsult> PostCitrixAccess(SRCitrixAccess sRCitrix)
        {
            return await _sRCitrix.PostCitrixAccess(sRCitrix);
        }
        [HttpGet("GetCrtirixAccess")]
        public async Task<CommonRsult> GetCitrixAccess()
        {
            return await _sRCitrix.GetCitrixAccess();
        }
        [HttpGet("GetCrtirixValue")]
        public async Task<CommonRsult> GetCitrixValue(int srid)
        {
            return await _sRCitrix.GetCitrixValue(srid);
        }
    }
}
