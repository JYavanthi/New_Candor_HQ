using IT_Portal.Application.Contracts.Persistence;
using IT_Portal.Application.Features;
using Microsoft.AspNetCore.Mvc;

namespace IT_Portal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupportTeamController : ControllerBase
    {
        private readonly ISupportTeam _suportcontext;

        public SupportTeamController(ISupportTeam suportcontext)
        {
            this._suportcontext = suportcontext;
        }

        [HttpGet]
        public async Task<IActionResult> GetSupportTeam()
        {
            var data = await _suportcontext.GetSuppotr();
            return Ok(data);
        }

        [HttpGet("supportteam")]
        public async Task<IActionResult> GetSupportAllTeam(int supportId)
        {
            var data = await _suportcontext.GetSuppotAll(supportId);
            return Ok(data);
        }


        [HttpGet("getSupportTeamById")]
        public async Task<IActionResult> getSupportTeamData(int supportTeamId)
        {
            var data = await _suportcontext.getSupportTeamData(supportTeamId);
            return Ok(data);
        }

        [HttpPost("PostSupportTeam")]
        public async Task<IActionResult> InsertChangeRequest([FromBody]SPSupportTeamTable obj)
        {
            var spObj = await _suportcontext.InsertSupportTeam(obj);
            return Ok(spObj);
        }


        [HttpPost("copySupportTeam")]
        public async Task<IActionResult> InsertChangeRequest(supportTeamCopy request)
        {
            var spObj = await _suportcontext.InsertSupportTeam(request);
            return Ok(spObj);
        }

    }
}
