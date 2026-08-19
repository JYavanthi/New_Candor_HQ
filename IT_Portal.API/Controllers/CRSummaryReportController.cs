using IT_Portal.Application.Contracts.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace IT_Portal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CRSummaryReportController : ControllerBase
    {
        private readonly ICRSummary _summarycontext;

        public CRSummaryReportController(ICRSummary summarycontext)
        {
            this._summarycontext = summarycontext;
        }

        [HttpGet("SummaryRepport")]
        public async Task<IActionResult> GetSummaryReport()
        {
            var data = await _summarycontext.GetSummaryRepport();
            return Ok(data);
        }
    }
}
