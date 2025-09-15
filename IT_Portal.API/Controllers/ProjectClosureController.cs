using IT_Portal.Application.Contracts.Persistence;
using IT_Portal.Application.Features;
using Microsoft.AspNetCore.Mvc;

namespace IT_Portal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectClosureController : ControllerBase
    {
        private readonly IProjectClosure _closure;

        public ProjectClosureController(IProjectClosure closure)
        {
            this._closure = closure;
        }
        [HttpPost("PostProjectclosure")]
        public async Task<CommonRsult> PostProjectclosure(ProjectClosure obj)
        {
            var data = await _closure.PostProjclosure(obj);
            return data;
        }

        [HttpGet("getClosureByProjectId")]
        public async Task<CommonRsult> getClosureByProjectId(int projectid)
        {
            return await _closure.getClosureByProjectId(projectid);
        }
    }
}
