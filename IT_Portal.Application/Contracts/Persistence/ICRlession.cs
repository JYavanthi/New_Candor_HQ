using IT_Portal.Application.Features;

namespace IT_Portal.Application.Contracts.Persistence
{
    public interface ICRlession
    {
        Task<CommonRsult> CRlession(SPCrlession crlession);
    }
}
