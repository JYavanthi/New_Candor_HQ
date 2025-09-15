using IT_Portal.Application.Contracts.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace IT_Portal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExecutionHistoryController : ControllerBase
    {
        private readonly ICRExecutionHistory _exehistorycontext;

        public ExecutionHistoryController(ICRExecutionHistory exehistorycontext)
        {
            this._exehistorycontext = exehistorycontext;
        }

        [HttpGet("ExecutionHistory")]
        public async Task<IActionResult> GetExecutionHistory()
        {
            var data = await _exehistorycontext.GetExecutionHistory();
            return Ok(data);
        }
    }
}
