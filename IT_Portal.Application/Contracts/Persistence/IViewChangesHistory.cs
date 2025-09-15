using IT_Portal.Application.Features;
using IT_Portal.Application.Features.GetHistoryData;

namespace IT_Portal.Application.Contracts.Persistence
{
    public interface IViewChangesHistory
    {
        Task<List<ECrApproverHistory>> GetCrApproverHistory(int crID);
        Task<List<ChangeRequestHistoryResultDto>> GetChangeRequestHistory(string crID);
        Task<List<EcrExecutionPlanHistory>> GetCrExecutionPlanHistory(int crID);

    }
}
