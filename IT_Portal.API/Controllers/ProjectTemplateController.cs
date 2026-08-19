using IT_Portal.Application.Contracts.Persistence;
using IT_Portal.Application.Features;
using Microsoft.AspNetCore.Mvc;

namespace IT_Portal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectTemplateController : ControllerBase
    {
        private readonly IProjectTemplate _template;

        public ProjectTemplateController(IProjectTemplate template)
        {
            this._template = template;
        }
        [HttpPost("SaveProjectTemplate")]

        public async Task<CommonRsult> saveProjectTemplate(SPProjectTemplate template)
        {
            var data = await _template.saveProjectTemplate(template);
            return data;
        }

        [HttpGet("getProjectTemplateByTemplateId")]
        public async Task<CommonRsult> getProjectTemplateByTemplateId(int templateId)
        {
            return await _template.getProjectTemplateByTemplateId(templateId);
        }

        [HttpGet("getProjectTemplate")]
        public async Task<CommonRsult> getProjectTemplate()
        {
            return await _template.getProjectTemplate();
        }


        [HttpGet("getProjectTemplateDetails")]
        public async Task<CommonRsult> getProjectTemplate(int templateId)
        {
            return await _template.getProjectTemplateDetailsByTemplateId(templateId);
        }
    }
}
