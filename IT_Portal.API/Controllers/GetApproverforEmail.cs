using IT_Portal.Application.Contracts.Persistence;
using IT_Portal.Application.Features;
using Microsoft.AspNetCore.Mvc;

namespace IT_Portal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetApproverforEmail : ControllerBase
    {

        private readonly IGetApproverEmail _iApproveremail;

        public GetApproverforEmail(IGetApproverEmail IApproveremail)
        {
            this._iApproveremail = IApproveremail;
        }
        [HttpPost("GetApproverEmail")]
        public async Task<IActionResult> GetApprover(SPGetApproverEmail getObj)
        {
            return Ok(await _iApproveremail.GetApproverEmail(getObj));
        }
    }
}
