using IT_Portal.Application.Features;

namespace IT_Portal.Application.Contracts.Persistence
{
    public interface IProjectLessons
    {
        Task<CommonRsult> saveProjectLessons(SPProjectLessons lessons);
        Task<CommonRsult> getProjectLessonsByProjectId(int proId);
        Task<CommonRsult> getProjectLessonByLessonId(int lessonId);
        Task<CommonRsult> saveTemplateDetails(templateDetails templateObj);
        Task<CommonRsult> saveTemplate(proSpTemplate templateObj);
        Task<CommonRsult> saveTemplateResponse(ProjectTemplateResponse templateObj);
        Task<CommonRsult> DeleteProjectTemplate(int TemplateID);
        Task<CommonRsult> DeleteProjectLeson(int LesonId);
        Task<CommonRsult> DeleteTemplateDtls(int TemplatedtlID);
    }
}
