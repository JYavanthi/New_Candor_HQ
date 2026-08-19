using IT_Portal.Application.Contracts.Persistence;
using IT_Portal.Application.Features;
using IT_Portal.Persistence.DatabaseContext;
using Microsoft.AspNetCore.Mvc;

namespace IT_Portal.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class projectGroup : ControllerBase
    {
        private readonly IprojectGroup _projectGroup;
        private readonly MicroLabsDevContext _context;

        public projectGroup(IprojectGroup projectGroup, MicroLabsDevContext context)
        {
            this._projectGroup = projectGroup;
            this._context = context;
        }


        [HttpPost("saveProject")]
        public async Task<IActionResult> InsertServiceMaster(SPprojectGroup request)
        {
            var spObj = await _projectGroup.PostProjectGroup(request);
            return Ok(spObj);
        }

        [HttpGet("getProjectGrops")]
        public async Task<IActionResult> getProjectGrops()
        {
            var spObj = await _projectGroup.getProjectGroup();
            return Ok(spObj);
        }

        [HttpGet("getProjectGropByID")]
        public async Task<IActionResult> getProjectGropByID(int id)
        {
            var spObj = await _projectGroup.getProjectGroupById(id);
            return Ok(spObj);
        }

    }
}
