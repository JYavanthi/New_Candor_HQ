using IT_Portal.Application.Contracts.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace IT_Portal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ViewChangeHistoryController : ControllerBase
    {
        private readonly IViewChangesHistory _changesHistory;

        public ViewChangeHistoryController(IViewChangesHistory changesHistory)
        {
            this._changesHistory = changesHistory;
        }
        [HttpGet("GetChangeRequestHistory")]
        public async Task<IActionResult> GetChangeRequestHistory(string id)
        {
            return Ok(await _changesHistory.GetChangeRequestHistory(id));
        }
        [HttpGet("GetCrApproverHistory")]
        public async Task<IActionResult> GetCrApproverHistory(int id)
        {
            return Ok(await _changesHistory.GetCrApproverHistory(id));
        }

        [HttpGet("GetCrExecutionPlanHistory")]
        public async Task<IActionResult> GetCrExecutionPlanHistory(int id)
        {
            return Ok(await _changesHistory.GetCrExecutionPlanHistory(id));
        }
    }
}
