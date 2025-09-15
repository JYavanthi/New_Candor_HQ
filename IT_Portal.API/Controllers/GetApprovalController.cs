using IT_Portal.Application.Contracts.Persistence;
using IT_Portal.Application.Features;
using IT_Portal.Persistence.DatabaseContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IT_Portal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetApprovalController : ControllerBase
    {
        private readonly IgetApprover _getApprover;
        private readonly MicroLabsDevContext _context;

        public GetApprovalController(IgetApprover getApprover, MicroLabsDevContext context)
        {
            this._getApprover = getApprover;
            this._context = context;
        }
        [HttpPost("GetApprover")]
        public async Task<IActionResult> GetApprover(SPgetApprove getObj)
        {
            return Ok(await _getApprover.GetApprover(getObj));
        }

        [HttpGet("GetApprover")]
        public async Task<IActionResult> GetApprover()
        {
            var data = await _context.Approvers.ToListAsync();
            return Ok(data);
        }
    }
}
