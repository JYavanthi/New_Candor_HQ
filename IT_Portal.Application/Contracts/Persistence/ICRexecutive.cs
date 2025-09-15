using IT_Portal.Application.Features;

namespace IT_Portal.Application.Contracts.Persistence
{
    public interface ICRexecutive
    {
        Task<CommonRsult> CRexecutive(SPCrexecute crexecute);
    }
}
