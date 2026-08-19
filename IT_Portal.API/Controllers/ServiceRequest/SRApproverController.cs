using IT_Portal.Application.Contracts.Persistence.SR;
using IT_Portal.Application.Features;
using Microsoft.AspNetCore.Mvc;

namespace IT_Portal.API.Controllers.ServiceRequest
{
    [Route("api/[controller]")]
    [ApiController]
    public class SRApproverController : ControllerBase
    {
        private readonly ISRApprover _approver;

        public SRApproverController(ISRApprover approver)
        {
            this._approver = approver;
        }

        [HttpPost("PostApprover")]
        public async Task<CommonRsult> PostApprover(SRApprover sRApprover)
        {
            var data = await _approver.PostApprover(sRApprover);
            return data;
        }
    }
}
