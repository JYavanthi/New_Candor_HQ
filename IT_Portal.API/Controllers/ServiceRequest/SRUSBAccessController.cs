using IT_Portal.Application.Contracts.Persistence.SR;
using IT_Portal.Application.Features;
using IT_Portal.Application.Features.SR;
using Microsoft.AspNetCore.Mvc;

namespace IT_Portal.API.Controllers.ServiceRequest
{
    [Route("api/[controller]")]
    [ApiController]
    public class SRUSBAccessController : ControllerBase
    {
        private readonly ISRUSBAccess _sRUSB;

        public SRUSBAccessController(ISRUSBAccess sRUSB)
        {
            this._sRUSB = sRUSB;
        }
        [HttpPost("PostSRUSB")]
        public async Task<CommonRsult> PostUSBAccess(SRUSBAccess sRURL)
        {
            var data = await _sRUSB.PostUSBAccess(sRURL);
            return data;
        }
        [HttpGet("GetSRUSB")]
        public async Task<CommonRsult> GetUSBAccess()
        {
            var data = await _sRUSB.GetUSBAccess();
            return data;
        }
        [HttpGet("GetSRUSBIDValue")]
        public async Task<CommonRsult> GetUSBAIdvalue(int srid)
        {
            var data = await _sRUSB.GetUSBIdValue(srid);
            return data;
        }
        [HttpGet("GetAssetDetails")]
        public async Task<CommonRsult> GetAssetDetails(string Empno)
        {
            var data = await _sRUSB.GetAssetDetails(Empno);
            return data;
        }
    }
}
