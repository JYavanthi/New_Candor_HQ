using IT_Portal.Application.Contracts.Persistence;
using IT_Portal.Application.Features;
using IT_Portal.Persistence.DatabaseContext;
//using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IT_Portal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class projectMilestoneController : ControllerBase
    {
        private readonly IprojectMilestone _spProjectMilestone;
        private readonly MicroLabsDevContext _context;
        public projectMilestoneController(IprojectMilestone spProjectMilestone, MicroLabsDevContext context)
        {
            this._spProjectMilestone = spProjectMilestone;
            this._context = context;
        }

        [HttpPost("saveProjectMilestone")]
        public async Task<IActionResult> saveProjectMilestone(SPProjectMilestone spProjectMilestone)
        {
            var spObj = await _spProjectMilestone.saveProjectMilestone(spProjectMilestone);
            return Ok(spObj);
        }

        [HttpGet("getProjectMilestone")]
        public async Task<CommonRsult> getProjectMilestone()
        {
            return await _spProjectMilestone.getProjectMilestone();
        }

        [HttpGet("getMilestoneByProjectId")]
        public async Task<CommonRsult> getMilestoneByProjectId(int id)
        {
            return await _spProjectMilestone.getMilestoneByProjectId(id);
        }

        [HttpGet("getMilestoneByMilestoneId")]
        public async Task<CommonRsult> getMilestoneByMilestoneId(int id)
        {
            return await _spProjectMilestone.getMilestoneByMilestoneId(id);
        }

        [HttpGet("DeleteMilestoneById")]
        public async Task<IActionResult> DeleteMilestoneById(int milestoneId)
        {
            var spObj = await _spProjectMilestone.DeleteMilestoneById(milestoneId);
            return Ok(spObj);
        }
    }

}
