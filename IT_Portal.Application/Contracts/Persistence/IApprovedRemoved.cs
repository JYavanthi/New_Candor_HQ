using IT_Portal.Application.Features;
using IT_Portal.Application.Features.GetApprover;

namespace IT_Portal.Application.Contracts.Persistence
{
    public interface IApprovedRemoved
    {
        Task<CommonRsult> postApprover(IApproverRemoved approverRemoved);
    }
}
