using IT_Portal.Application.Contracts.Persistence;
using IT_Portal.Application.Features;
using Microsoft.AspNetCore.Mvc;

namespace IT_Portal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IssueAssignedToController : ControllerBase
    {
        private readonly IIssueAssignedTo _issueasignedcontext;

        public IssueAssignedToController(IIssueAssignedTo issueasignedcontext)
        {
            this._issueasignedcontext = issueasignedcontext;
        }

        [HttpPost("Issueassignedto")]
        public async Task<IActionResult> InsertIssueList(SPIssueAssignedTo obj)
        {
            var spObj = await _issueasignedcontext.PostIssueAssignedTo(obj);
            return Ok(spObj);
        }

        [HttpPost("IssueForwardTo")]
        public async Task<IActionResult> ForwardTo(EForwardToRequest obj)
        {
            var spObj = await _issueasignedcontext.issueForwardTo(obj);
            return Ok(spObj);
        }
    }
}
