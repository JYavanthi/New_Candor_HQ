using IT_Portal.Application.Contracts.Persistence;
using IT_Portal.Application.Features.GetApprover;
using Microsoft.AspNetCore.Mvc;

namespace IT_Portal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApproverRemovedController : ControllerBase
    {
        private readonly IApprovedRemoved _approvedRemoved;

        public ApproverRemovedController(IApprovedRemoved approvedRemoved)
        {
            this._approvedRemoved = approvedRemoved;
        }

        [HttpPost("UpdateSupportTeam")]
        public async Task<IActionResult> postApprover(IApproverRemoved obj)
        {
            var spObj = await _approvedRemoved.postApprover(obj);
            return Ok(spObj);
        }
    }
}
