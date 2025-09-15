using IT_Portal.Application.Features;
using IT_Portal.Application.Features.SR;

namespace IT_Portal.Application.Contracts.Persistence.SR
{
    public interface ISRFileAccess
    {
        Task<CommonRsult> PostSRFileAccess(SRFileAccess fileAccess);
        Task<CommonRsult> GetSRFileAccess();
        Task<CommonRsult> GetSRFileAccessValue(int srid);
    }
}
