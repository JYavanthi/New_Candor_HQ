using IT_Portal.Application.Contracts.Persistence;
using IT_Portal.Application.Features;
using IT_Portal.Persistence.DatabaseContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IT_Portal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ViewChangeRequestController : ControllerBase
    {
        private readonly IViewChangeRequest _vwcrcontext;
        private readonly MicroLabsDevContext _context;

        public ViewChangeRequestController(IViewChangeRequest vwcrcontext, MicroLabsDevContext context)
        {
            this._vwcrcontext = vwcrcontext;
            this._context = context;
        }

        [HttpGet("ViewChangerequest")]
        public async Task<IActionResult> GetApproverHistory([FromQuery] EcrFilterRequest filteRequest)
        {
            var data = await _context.VwChangeRequests.ToListAsync();
            /*var data = await _vwcrcontext.GetVieChangerequets(filteRequest);*/
            return Ok(data);
        }

        [HttpGet("getApprovedCR")]
        public async Task<IActionResult> GetApproverHistory(int apprId)
        {
            var data = await _context.VwRptapproverViews.Where(m => m.ApproverId == apprId).ToListAsync();
            return Ok(data);
        }

        [HttpGet("getMileStoneCR")]
        public async Task<IActionResult> getMileStoneCR()
        {
            var data = await _context.VwRptcrmilestones.ToListAsync();
            return Ok(data);
        }
    }
}
