using IT_Portal.Application.Features;

namespace IT_Portal.Application.Contracts.Persistence
{
    public interface IChecklistTemplate
    {
        Task<CommonRsult> PostChecklistTemplate(SPChecklistTemplate sPProject);
        Task<CommonRsult> GetChecklistTemplate();
        Task<CommonRsult> GetCheckList();
        Task<CommonRsult> deleteChecklistTemplate(int id);
    }
}
