using IT_Portal.Application.Contracts.Persistence;
using IT_Portal.Application.Features;
using Microsoft.AspNetCore.Mvc;

namespace IT_Portal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChecklistTemplateController : ControllerBase
    {
        private readonly IChecklistTemplate _checklist;

        public ChecklistTemplateController(IChecklistTemplate checklist)
        {
            this._checklist = checklist;
        }
        [HttpPost("PostCheklistTemplate")]
        public async Task<CommonRsult> PostChecklistTemplate(SPChecklistTemplate sPProject)
        {
            var Data = await _checklist.PostChecklistTemplate(sPProject);
            return Data;
        }
        [HttpGet("GetChecklistTemplate")]
        public async Task<CommonRsult> GetChecklistTemplate()
        {
            return await _checklist.GetChecklistTemplate();
        }


        [HttpGet("GetChecklist")]
        public async Task<CommonRsult> GetChecklist()
        {
            return await _checklist.GetCheckList();
        }


        [HttpGet("DeleteTemplateChecklist")]
        public async Task<CommonRsult> deletChecklistTemplate(int id)
        {
            return await _checklist.deleteChecklistTemplate(id);
        }
    }
}
