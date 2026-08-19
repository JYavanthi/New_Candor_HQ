using IT_Portal.Application.Contracts.Persistence;
using IT_Portal.Application.Features;
using IT_Portal.Persistence.DatabaseContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IT_Portal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VwApproverCRController : ControllerBase
    {
        private readonly IVWApproverCR _viewapprovercontext;
        private readonly MicroLabsDevContext _context;

        public VwApproverCRController(IVWApproverCR viewapprovercontext, MicroLabsDevContext context)
        {
            this._viewapprovercontext = viewapprovercontext;
            this._context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetSupportTeam()
        {
            var data = await _viewapprovercontext.GetApproversCR();
            return Ok(data);
        }

        [HttpGet("getapproverData")]
        public async Task<IActionResult> GetApproverData([FromQuery] ErequesGetApprover request)
        {
            var data = await _viewapprovercontext.GetCrApproverData(request);
            return Ok(data);
        }


        [HttpGet("getPendingForApprovalCR")]
        public async Task<IActionResult> GetApproverView(int id)
        {
            try
            {
                var data = await _context.VwApproverViews.Where(m => m.Approver1 == id).ToListAsync();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }

    }
}
