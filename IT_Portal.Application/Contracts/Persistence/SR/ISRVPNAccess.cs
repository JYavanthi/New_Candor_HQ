using IT_Portal.Application.Features;
using IT_Portal.Application.Features.SR;

namespace IT_Portal.Application.Contracts.Persistence.SR
{
    public interface ISRVPNAccess
    {
        Task<CommonRsult> PostVPNAccess(SRVPNAccess sRVPN);
        Task<CommonRsult> GetVPNAccess();
        Task<CommonRsult> GetVPNAccessValue(int srid);
    }
}
