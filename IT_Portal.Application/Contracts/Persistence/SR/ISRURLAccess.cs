using IT_Portal.Application.Features;
using IT_Portal.Application.Features.SR;

namespace IT_Portal.Application.Contracts.Persistence.SR
{
    public interface ISRURLAccess
    {
        Task<CommonRsult> PostURLAccess(SRURLAccess sRURL);
        Task<CommonRsult> GetURLAccess();
        Task<CommonRsult> GetURLAccessValue(int srid);
    }
}
