using IT_Portal.Application.Contracts.Persistence;
using IT_Portal.Application.Features;
using IT_Portal.Persistence.DatabaseContext;
using Microsoft.AspNetCore.Mvc;

namespace IT_Portal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class projectIssueController : ControllerBase
    {
        private readonly IprojectIssue _model;
        private readonly MicroLabsDevContext _context;
        public projectIssueController(IprojectIssue model, MicroLabsDevContext context)
        {
            this._model = model;
            this._context = context;
        }

        [HttpPost("saveProjectIssue")]
        public async Task<IActionResult> saveProjectPRoIssue(SPprojectIssue obj)
        {
            var spObj = await _model.saveProjectIssue(obj);
            return Ok(spObj);
        }


        [HttpGet("getProIssueById")]
        public async Task<CommonRsult> getProIssueById(int id)
        {
            return await _model.getProIssueById(id);
        }


        [HttpGet("getProIssueByProId")]
        public async Task<CommonRsult> getProIssueProIdById(int id)
        {
            return await _model.getProIssueProById(id);
        }


        [HttpGet("deleteProjectIssueById")]
        public async Task<IActionResult> deleteProjectIssueById(int issueId)
        {
            var spObj = await _model.deleteProjectIssueById(issueId);
            return Ok(spObj);
        }
    }
}
