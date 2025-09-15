using IT_Portal.Application.Features;

namespace IT_Portal.Application.Contracts.Persistence
{
    public interface IViewChangeRequest
    {
        Task<CommonRsult> GetVieChangerequets(EcrFilterRequest filterRquest);
    }
}
