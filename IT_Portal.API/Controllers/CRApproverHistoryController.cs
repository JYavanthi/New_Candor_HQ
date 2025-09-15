using IT_Portal.Application.Contracts.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace IT_Portal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CRApproverHistoryController : ControllerBase
    {
        private readonly ICRApproverHistory _crapproverhistorycontext;

        public CRApproverHistoryController(ICRApproverHistory crapproverhistorycontext)
        {
            this._crapproverhistorycontext = crapproverhistorycontext;
        }

        [HttpGet("ApproverHistory")]
        public async Task<IActionResult> GetApproverHistory()
        {
            var data = await _crapproverhistorycontext.GetCRApproverHistory();
            return Ok(data);
        }
    }
}
