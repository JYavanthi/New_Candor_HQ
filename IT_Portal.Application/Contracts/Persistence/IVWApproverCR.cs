using IT_Portal.Application.Features;
using IT_Portal.Persistence.IT_Models;

namespace IT_Portal.Application.Contracts.Persistence
{
    public interface IVWApproverCR
    {
        Task<List<VwApproverCr>> GetApproversCR();

        public Task<List<Approver>> GetCrApproverData(ErequesGetApprover apprReq);
    }
}
