using IT_Portal.Application.Contracts.Persistence;
using IT_Portal.Application.Features;
using IT_Portal.Persistence.DatabaseContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IT_Portal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupportteamAssignedController : ControllerBase
    {
        private readonly ISupportteamAssigned _supportassignedcontext;
        private readonly MicroLabsDevContext _context;

        public SupportteamAssignedController(ISupportteamAssigned supportassignedcontext, MicroLabsDevContext context)
        {
            this._supportassignedcontext = supportassignedcontext;
            this._context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetsupportTeam()
        {
            var data = await _context.SupportTeamAssgns.ToListAsync();
            return Ok(data);
        }


        [HttpGet("supportTeamById")]
        public async Task<IActionResult> getSupportTeamAssign(int supportTeamId)
        {

            CommonRsult result = new CommonRsult();
            try
            {
                var data = await _context.SupportTeamAssgns.Where(m => m.SupportTeamId == supportTeamId).ToListAsync();
                result.Data = data;
            }
            catch (Exception ex)
            {
                result.Data = ex.Message;
            }
            return Ok(result);
        }
    }
}
