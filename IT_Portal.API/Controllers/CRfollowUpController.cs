using IT_Portal.Application.Contracts.Persistence;
using IT_Portal.Application.Features;
using IT_Portal.Persistence.DatabaseContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IT_Portal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CRfollowUpController : ControllerBase
    {
        private readonly ICRfollowUp _followupcontext;
        private readonly MicroLabsDevContext _context;

        public CRfollowUpController(ICRfollowUp followupcontext, MicroLabsDevContext context)
        {
            this._followupcontext = followupcontext;
            this._context = context;
        }

        [HttpPost("Followup")]
        public async Task<IActionResult> CRFollowup(SPCrfollowUp obj)
        {
            var spObj = await _followupcontext.CRfollowup(obj);
            return Ok(spObj);
        }
        [HttpGet("GetFollow")]
        public async Task<IActionResult> GetRequest()
        {
            var data = await _context.Crfollowups.ToListAsync();
            return Ok(data);
        }
    }
}
