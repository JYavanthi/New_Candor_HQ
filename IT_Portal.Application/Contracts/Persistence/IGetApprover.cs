using IT_Portal.Application.Features;
using IT_Portal.Application.Features.GetApprover;

namespace IT_Portal.Application.Contracts.Persistence
{
    public interface IgetApprover
    {
        Task<List<GetApproverResultSP>> GetApprover(SPgetApprove getApprove);
    }
}
