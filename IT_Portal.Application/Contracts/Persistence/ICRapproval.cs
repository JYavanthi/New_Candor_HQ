using IT_Portal.Application.Features;

namespace IT_Portal.Application.Contracts.Persistence
{
    public interface ICRapproval
    {
        Task<CommonRsult> CRapprove(SPCrapprove crapprove);
    }
}
