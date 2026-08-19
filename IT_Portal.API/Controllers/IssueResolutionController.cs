using IT_Portal.Application.Contracts.Persistence;
using IT_Portal.Application.Features;
using Microsoft.AspNetCore.Mvc;

namespace IT_Portal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IssueResolutionController : ControllerBase
    {
        private readonly IissueResolution _issueresolutioncontext;

        public IssueResolutionController(IissueResolution issueresolutioncontext)
        {
            this._issueresolutioncontext = issueresolutioncontext;
        }

        [HttpPost("IssueResolution")]
        public async Task<IActionResult> InsertIssueList(SPIssueResolution obj)
        {
            var spObj = await _issueresolutioncontext.PostIssueRosulation(obj);
            return Ok(spObj);
        }

        [HttpPost("updateIssueStatus")]
        public async Task<IActionResult> updateIssueStatus(ErequestStatus obj)
        {
            var spObj = await _issueresolutioncontext.updateStatus(obj);
            return Ok(spObj);
        }

        [HttpPost("updateIssueStatusBulk")]
        public async Task<IActionResult> updateIssueStatusBulk([FromBody] EbulkIssueStatusChange request)
        {
            var spObj = await _issueresolutioncontext.updateStatusBulk(request);
            return Ok(spObj);
        }
    }
}
