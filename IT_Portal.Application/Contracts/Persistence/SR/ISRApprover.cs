using IT_Portal.Application.Features;

namespace IT_Portal.Application.Contracts.Persistence.SR
{
    public interface ISRApprover
    {
        Task<CommonRsult> PostApprover(SRApprover sRApprover);
        Task<CommonRsult> getApprover(int srId);
    }
}
