using IT_Portal.Application.Features;

namespace IT_Portal.Application.Contracts.Persistence
{
    public interface IProjectTemplate
    {
        Task<CommonRsult> saveProjectTemplate(SPProjectTemplate template);
        Task<CommonRsult> getProjectTemplateByTemplateId(int templateId);
        Task<CommonRsult> getProjectTemplateDetailsByTemplateId(int templateId);
        Task<CommonRsult> getProjectTemplateDetailsResByTemplateId(int templateId, int lessonLearnedId);
        Task<CommonRsult> getProjectTemplate();

    }
}
