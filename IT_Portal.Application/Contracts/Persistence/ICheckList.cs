using IT_Portal.Application.Features;
using IT_Portal.Domain.IT_Models;

namespace IT_Portal.Application.Contracts.Persistence
{
    public interface ICheckList
    {
        Task<List<VwChecklist>> Getchecklist();

        Task<CommonRsult> postchecklist(SPCheckList checklist);
    }
}
