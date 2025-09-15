using IT_Portal.Application.Features;

namespace IT_Portal.Application.Contracts.Persistence
{
    public interface ICrrelease
    {
        Task<CommonRsult> CRrelease(SPCrrelease crrelease);
    }
}
