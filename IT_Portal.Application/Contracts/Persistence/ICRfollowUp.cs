using IT_Portal.Application.Features;

namespace IT_Portal.Application.Contracts.Persistence
{
    public interface ICRfollowUp
    {
        Task<CommonRsult> CRfollowup(SPCrfollowUp crfollowUp);
    }
}
