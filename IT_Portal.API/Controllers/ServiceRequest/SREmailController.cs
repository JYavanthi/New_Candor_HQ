using IT_Portal.Application.Contracts.Persistence.SR;
using IT_Portal.Application.Features;
using IT_Portal.Application.Features.SR;
using Microsoft.AspNetCore.Mvc;

namespace IT_Portal.API.Controllers.ServiceRequest
{
    [Route("api/[controller]")]
    [ApiController]
    public class SREmailController : ControllerBase
    {
        private readonly ISREmail _sRE;

        public SREmailController(ISREmail sRE)
        {
            this._sRE = sRE;
        }

        [HttpPost("PostSREmail")]
        public async Task<CommonRsult> PostEmailReq(SREmailRequest sREmail)
        {
            return await _sRE.PostEmailReq(sREmail);
        }

        [HttpGet("GetSREmailByID")]
        public async Task<CommonRsult> GetEmailvalue(int srId)
        {
            return await (_sRE.GetEmailvalue(srId));
        }

        [HttpGet("GetSREmailGroups")]
        public async Task<CommonRsult> GetSREmailGroups()
        {
            return await (_sRE.GetSREmailGroups());
        }
    }
}