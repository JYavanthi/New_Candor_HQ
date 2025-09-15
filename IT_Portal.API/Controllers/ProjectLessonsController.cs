using IT_Portal.Application.Contracts.Persistence;
using IT_Portal.Application.Features;
using Microsoft.AspNetCore.Mvc;

namespace IT_Portal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectLessonsController : ControllerBase
    {
        private readonly IProjectLessons _project;

        public ProjectLessonsController(IProjectLessons project)
        {
            this._project = project;
        }
        [HttpPost("PostProjectLesson")]
        public async Task<CommonRsult> saveProjectLessons(SPProjectLessons lessons)
        {
            var data = await _project.saveProjectLessons(lessons);
            return data;
        }

        [HttpGet("getProjectLessonsByProjectId")]
        public async Task<CommonRsult> getProjectLessonsByProjectId(int projectid)
        {
            return await _project.getProjectLessonsByProjectId(projectid);
        }

        [HttpGet("getProjectLessonByLessonId")]
        public async Task<CommonRsult> getProjectLessonByLessonId(int lessonId)
        {
            return await _project.getProjectLessonByLessonId(lessonId);
        }

        [HttpPost("saveTemplate")]
        public async Task<CommonRsult> saveTemplate(proSpTemplate templateObj)
        {
            return await _project.saveTemplate(templateObj);
        }

        [HttpPost("saveTemplateDetails")]
        public async Task<CommonRsult> saveTemplateDetails(templateDetails templateObj)
        {
            return await _project.saveTemplateDetails(templateObj);
        }

        [HttpPost("saveTemplateResponses")]
        public async Task<CommonRsult> saveTemplateResponse(ProjectTemplateResponse templateObj)
        {
            return await _project.saveTemplateResponse(templateObj);
        }
        [HttpDelete("DeleteTemplate")]
        public async Task<CommonRsult> DeleteProjectTemplate(int TemplateID)
        {
            return await _project.DeleteProjectTemplate(TemplateID);
        }
        [HttpDelete("DeleteTemplateDtl")]
        public async Task<CommonRsult> DeleteTemplateDtls(int TemplatedtlID)
        {
            return await _project.DeleteTemplateDtls(TemplatedtlID);
        }


        [HttpDelete("DeleteDeleteLesson")]
        public async Task<CommonRsult> DeleteProjectLesson(int LesonId)
        {
            return await _project.DeleteProjectLeson(LesonId);
        }
    }
}
