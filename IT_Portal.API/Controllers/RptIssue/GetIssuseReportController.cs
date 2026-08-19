using IT_Portal.Application.Contracts.Persistence.RptIssue;
using IT_Portal.Application.Features;
using IT_Portal.Persistence.DatabaseContext;
using Microsoft.AspNetCore.Mvc;

namespace IT_Portal.API.Controllers.RptIssue
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetIssuseReportController : ControllerBase
    {
        private readonly MicroLabsDevContext _context;
        private readonly IGetIssueReport _getIssueReport;

        public GetIssuseReportController(MicroLabsDevContext context, IGetIssueReport getIssueReport)
        {
            this._context = context;
            this._getIssueReport = getIssueReport;
        }

        [HttpGet("IssueReport")]
        public async Task<CommonRsult> GetIssueReport([FromQuery] EcrFilterRequest filterRquest)
        {
            var Data = await _getIssueReport.GetIssueReport(filterRquest);
            return Data;
        }
        [HttpGet("IssueResolution")]
        public async Task<CommonRsult> GetIssueResolutoin([FromQuery] EcrFilterRequest filterRquest)
        {
            var Data = await _getIssueReport.GetIssueResolutoin(filterRquest);
            return Data;
        }


    }
}
